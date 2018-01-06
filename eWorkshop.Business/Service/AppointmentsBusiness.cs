using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWorkshop.Data;
using eWorkshop.Data.Service;
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

		public async override Task<List<AppointmentsEntity>> GetByFilterAsync(AppointmentsFilter filter)
		{
			var result = await base.GetByFilterAsync(filter);

			if (result.Any() && filter.LoadServices)
			{
				var idAppointments = result.Select(c => c.IdAppointment).ToList();
				var services = await AppointmentsServicesBusiness.GetByFilterAsync(new AppointmentsServicesFilter { IdAppointments = idAppointments });

				result.ForEach(item =>
				{
					item.Services.AddRange(services.Where(s => s.IdAppointment == item.IdAppointment));
				});
			}

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
