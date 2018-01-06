using XCommon.Patterns.Repository;
using eWorkshop.Data;
using eWorkshop.Data.Service;
using eWorkshop.Entity.Service;
using eWorkshop.Entity.Service.Filter;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Business.Service
{
	public class AppointmentsServicesBusiness: RepositoryEFBase<AppointmentsServicesEntity, AppointmentsServicesFilter, AppointmentsServices, eWorkConext>
	{
		[Inject]
		private ServicesBusiness ServicesBusiness { get; set; }

		public async override Task<List<AppointmentsServicesEntity>> GetByFilterAsync(AppointmentsServicesFilter filter)
		{
			var result = await base.GetByFilterAsync(filter);

			var services = await ServicesBusiness.GetByFilterAsync(new ServicesFilter { });

			result.ForEach(c => 
			{
				c.Service = services.FirstOrDefault(x => x.IdService == c.IdService);
				c.Service.Selected = true;
			});
			
			return result;
		}
	}
}
