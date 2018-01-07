using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWorkshop.Business.Register;
using eWorkshop.Data;
using eWorkshop.Data.Service;
using eWorkshop.Entity.Register.Filter;
using eWorkshop.Entity.Service;
using eWorkshop.Entity.Service.Filter;
using Microsoft.EntityFrameworkCore;
using XCommon.Application.Executes;
using XCommon.Patterns.Ioc;
using XCommon.Patterns.Repository;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Business.Service
{
	public class AppointmentsBusiness : RepositoryEFBase<AppointmentsEntity, AppointmentsFilter, Appointments, eWorkConext>
	{
		[Inject]
		private AppointmentsServicesBusiness AppointmentsServicesBusiness { get; set; }

		[Inject]
		private CarsBusiness CarsBusiness { get; set; }

		[Inject]
		private PeopleBusiness PeopleBusiness { get; set; }

		[Inject]
		private AddressesBusiness AddressesBusiness { get; set; }

		public async override Task<List<AppointmentsEntity>> GetByFilterAsync(AppointmentsFilter filter)
		{
			var result = await base.GetByFilterAsync(filter);

			if (!result.Any())
			{
				return result;
			}

			var idAppointments = result.Select(c => c.IdAppointment).ToList();
			var idWorkshop = result.Select(c => c.IdWorkshop).ToList();
			var idCars = result.Select(c => c.IdCar).ToList();
			var idAddress = result.Select(c => c.IdAddress).ToList();

			var cars = await CarsBusiness.GetByFilterAsync(new CarsFilter { Keys = idCars });
			var idPeople = cars.Select(c => c.IdPerson).ToList();

			var customers = await PeopleBusiness.GetByFilterAsync(new PeopleFilter { Keys = idPeople });
			var workShop = await PeopleBusiness.GetByFilterAsync(new PeopleFilter { Keys = idWorkshop });
			var addresses = await AddressesBusiness.GetByFilterAsync(new AddressesFilter { Keys = idAddress });

			var services = await AppointmentsServicesBusiness.GetByFilterAsync(new AppointmentsServicesFilter { IdAppointments = idAppointments });

			result.ForEach(item =>
			{
				item.Address = addresses.FirstOrDefault(c => c.IdAddress == item.IdAddress);
				item.Workshop = workShop.FirstOrDefault(c => c.IdPerson == item.IdWorkshop);
				item.Car = cars.FirstOrDefault(c => c.IdCar == item.IdCar);
				item.Customer = customers.FirstOrDefault(c => c.IdPerson == item.Car.IdPerson);
				item.Services.AddRange(services.Where(s => s.IdAppointment == item.IdAppointment));
			});

			return result;
		}

		protected async override Task<Execute> SaveAsync(List<AppointmentsEntity> entitys, DbContext context)
		{
			var result = new Execute();

			var idAppointments = entitys.Select(c => c.IdAppointment).ToList();

			var newServices = entitys.SelectMany(c => c.Services).ToList();
			newServices.RemoveAll(c => !c.Service.Selected);
			newServices.ForEach(c => c.Action = EntityAction.New);

			var oldServices = await AppointmentsServicesBusiness.GetByFilterAsync(new AppointmentsServicesFilter { IdAppointments = idAppointments });
			oldServices.ForEach(c => c.Action = EntityAction.Delete);

			using (var trans = context.Database.BeginTransaction())
			{
				result.AddMessage(await base.SaveAsync(entitys, context));
				result.AddMessage(await AppointmentsServicesBusiness.SaveManyAsync(oldServices, context));
				result.AddMessage(await AppointmentsServicesBusiness.SaveManyAsync(newServices, context));

				if (!result.HasErro)
				{
					trans.Commit();
				}
			}

			return result;
		}
	}
}
