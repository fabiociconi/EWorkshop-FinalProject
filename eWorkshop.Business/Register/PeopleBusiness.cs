using System;
using System.Linq;
using System.Threading.Tasks;
using eWorkshop.Data;
using eWorkshop.Data.Register;
using eWorkshop.Entity.Register;
using eWorkshop.Entity.Register.Filter;
using XCommon.Application.Executes;
using XCommon.Extensions.String;
using XCommon.Patterns.Ioc;
using XCommon.Patterns.Repository;
using XCommon.Util;

namespace eWorkshop.Business.Register
{
	public class PeopleBusiness: RepositoryEFBase<PeopleEntity, PeopleFilter, People, eWorkConext>
    {
		[Inject]
		private UsersBusiness UsersBusiness { get; set; }

		public async Task<Execute<TokenEntity>> SignUpAsync(SignUpEntity signUp)
		{
			var result = new Execute<TokenEntity>(new TokenEntity());

			try
			{
				var userEntity = ParseUser(signUp);
				using (var db = new eWorkConext())
				{
					using (var transaction = db.Database.BeginTransaction())
					{
						result.AddMessage(await SaveAsync(signUp, db));
						result.AddMessage(await UsersBusiness.SaveAsync(userEntity, db));

						db.SaveChanges();

						if (!result.HasErro)
						{
							transaction.Commit();
						}
					}

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
