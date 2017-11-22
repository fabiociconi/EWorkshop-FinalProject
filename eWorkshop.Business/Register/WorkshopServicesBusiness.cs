using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWorkshop.Business.Service;
using eWorkshop.Data;
using eWorkshop.Data.Register;
using eWorkshop.Entity.Register;
using eWorkshop.Entity.Register.Filter;
using eWorkshop.Entity.Service.Filter;
using Microsoft.EntityFrameworkCore;
using XCommon.Application.Executes;
using XCommon.Patterns.Ioc;
using XCommon.Patterns.Repository;

namespace eWorkshop.Business.Register
{
	public class WorkshopServicesBusiness: RepositoryEFBase<WorkshopServicesEntity, WorkshopServicesFilter, WorkshopServices, eWorkConext>
	{
		[Inject]
		private ServicesBusiness ServicesBusiness { get; set; }

		[Inject]
		private ITicketInfo Info { get; set; }

		protected override async Task<Execute> SaveAsync(List<WorkshopServicesEntity> entitys, DbContext context)
		{
			entitys.ForEach(c => c.IdWorkshop = Info.UserKey);
			return await base.SaveAsync(entitys, context);
		}

		public override async Task<List<WorkshopServicesEntity>> GetByFilterAsync(WorkshopServicesFilter filter)
		{
			var services = await ServicesBusiness.GetByFilterAsync(new ServicesFilter { });
			var result = await base.GetByFilterAsync(filter);

			result.ForEach(c => 
			{
				c.Service = services.FirstOrDefault(x => x.IdService == c.IdService);
			});
			
			return result;
		}
	}
}
