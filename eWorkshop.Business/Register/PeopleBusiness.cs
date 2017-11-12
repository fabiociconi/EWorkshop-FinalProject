using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWorkshop.Data;
using eWorkshop.Data.Register;
using eWorkshop.Entity.Enum;
using eWorkshop.Entity.Register;
using eWorkshop.Entity.Register.Filter;
using Microsoft.EntityFrameworkCore;
using XCommon.Application.Executes;
using XCommon.Extensions.String;
using XCommon.Patterns.Ioc;
using XCommon.Patterns.Repository;
using XCommon.Patterns.Repository.Entity;
using XCommon.Util;

namespace eWorkshop.Business.Register
{
	public class PeopleBusiness : RepositoryEFBase<PeopleEntity, PeopleFilter, People, eWorkConext>
	{
		[Inject]
		private UsersBusiness UsersBusiness { get; set; }

		[Inject]
		private CustomersBusiness CustomersBusiness { get; set; }

		[Inject]
		private WorkshopsBusiness WorkshopsBusiness { get; set; }

		protected override async Task<Execute> SaveAsync(List<PeopleEntity> entitys, DbContext context)
		{
			var result = new Execute();

			entitys.ForEach(e =>
			{
				if (e.Customer != null)
				{
					e.Customer.Action = e.Action;
				}

				if (e.Workshop != null)
				{
					e.Workshop.Action = e.Action;
				}
			});

			var customers = entitys.Where(c => c.Customer != null).Select(c => c.Customer).ToList();
			var workshops = entitys.Where(c => c.Workshop != null).Select(c => c.Workshop).ToList();

			using (var transaction = context.Database.BeginTransaction())
			{
				result.AddMessage(await base.SaveAsync(entitys, context));

				if (customers.Any())
				{
					result.AddMessage(await CustomersBusiness.SaveManyAsync(customers, context));
				}

				if (workshops.Any())
				{
					result.AddMessage(await WorkshopsBusiness.SaveManyAsync(workshops, context));
				}

				if (!result.HasErro)
				{
					transaction.Commit();
				}
			}

			return result;
		}

		public async override Task<List<PeopleEntity>> GetByFilterAsync(PeopleFilter filter)
		{
			var result = await base.GetByFilterAsync(filter);

			if (!result.Any())
			{
				return result;
			}

			var idPeople = result.Select(c => c.IdPerson).ToList();

			if (filter.LoadDetails)
			{
				var users = await UsersBusiness.GetByFilterAsync(new UsersFilter { Keys = idPeople });
				var customers = await CustomersBusiness.GetByFilterAsync(new CustomersFilter { Keys = idPeople });
				var workshops = await WorkshopsBusiness.GetByFilterAsync(new WorkshopsFilter { Keys = idPeople });

				result.ForEach(person =>
				{
					var user = users.FirstOrDefault(u => u.IdPerson == person.IdPerson);

					person.Role = user.Role;
					person.Customer = customers.FirstOrDefault(u => u.IdPerson == person.IdPerson);
					person.Workshop = workshops.FirstOrDefault(u => u.IdPerson == person.IdPerson);
				});
			}

			return result;
		}

		public async Task<Execute<TokenEntity>> SignUpAsync(SignUpEntity signUp)
		{
			var result = new Execute<TokenEntity>(new TokenEntity());

			try
			{
				if (signUp.Role == RoleType.Customer)
				{
					signUp.Customer = new CustomersEntity
					{
						Action = EntityAction.New,
						IdCustomer = signUp.Key,
						IdPerson = signUp.Key
					};
				}

				if (signUp.Role == RoleType.Workshop)
				{
					signUp.Workshop = new WorkshopsEntity
					{
						Action = EntityAction.New,
						IdWorkshop = signUp.Key,
						IdPerson = signUp.Key
					};
				}

				var userEntity = ParseUser(signUp);


				using (var db = new eWorkConext())
				{
					result.AddMessage(await SaveAsync(signUp, db));
					result.AddMessage(await UsersBusiness.SaveAsync(userEntity, db));

					result.Entity.IdPerson = signUp.IdPerson;
					result.Entity.RoleType = signUp.RoleType;
					result.Entity.FirstName = signUp.FirstName;
					result.Entity.LastName = signUp.LastName;
				}
			}
			catch (Exception ex)
			{
				result.AddMessage(ex, "Error creating new register");
			}

			return result;
		}

		public async Task<Execute<TokenEntity>> SignInAsync(SignInEntity signIn)
		{
			var result = new Execute<TokenEntity>();


			if (signIn == null || signIn.Email.IsEmpty() || signIn.Password.IsEmpty())
			{
				result.AddMessage(ExecuteMessageType.Error, "Invalid data");
				return result;
			}

			var people = await GetByFilterAsync(new PeopleFilter { Email = signIn.Email });

			if (people == null || people.Count != 1)
			{
				result.AddMessage(ExecuteMessageType.Error, "Invalid email/passowrd");
				return result;
			}

			var person = people.FirstOrDefault();
			var users = await UsersBusiness.GetByFilterAsync(new UsersFilter { Key = person.IdPerson, Password = Functions.GetMD5(signIn.Password) });

			if (users == null || users.Count != 1)
			{
				result.AddMessage(ExecuteMessageType.Error, "Invalid email/passowrd");
				return result;
			}

			var user = users.FirstOrDefault();

			result.Entity = new TokenEntity
			{
				IdPerson = person.IdPerson,
				FirstName = person.FirstName,
				LastName = person.LastName,
				RoleType = user.Role
			};

			return result;
		}

		private UsersEntity ParseUser(SignUpEntity register)
		{
			return new UsersEntity
			{
				Action = register.Action,
				IdPerson = register.IdPerson,
				IdUser = register.IdPerson,
				Password = Functions.GetMD5(register.Password),
				Role = register.RoleType
			};
		}
	}
}
