using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eWorkshop.Business.Service;
using eWorkshop.Entity.Service;
using eWorkshop.Entity.Service.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Web.Controllers
{
	[Route("api/[controller]")]
	[Authorize]
	public class CommonController : BaseController
    {
		[Inject]
		private ServicesBusiness ServicesBusiness { get; set; }

		[HttpGet("service")]
		public async Task<List<ServicesEntity>> GetServices()
		{
			return await ServicesBusiness.GetByFilterAsync(new ServicesFilter { IdService = UserKey });
		}

		[HttpGet("service/{id}")]
		public async Task<ServicesEntity> GetService(Guid id)
		{
			return await ServicesBusiness.GetFirstByFilterAsync(new ServicesFilter { IdService = UserKey, Key = id });
		}
	}
}
