using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWorkshop.Business.Register;
using eWorkshop.Business.Service;
using eWorkshop.Entity.Enum;
using eWorkshop.Entity.Register;
using eWorkshop.Entity.Register.Filter;
using eWorkshop.Entity.Service;
using eWorkshop.Entity.Service.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XCommon.Application.Executes;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Web.Controllers
{
	[Route("api/[controller]")]
	public class WorkshopController : BaseController
    {
		[Inject]
		private PeopleBusiness PeopleBusiness { get; set; }

		[Inject]
		private AddressesBusiness AddressesBusiness { get; set; }

		[Inject]
		private WorkshopServicesBusiness WorkshopServicesBusiness { get; set; }

		[Inject]
		private CarsBusiness CarsBusiness { get; set; }

		[Inject]
		private ServicesBusiness ServicesBusiness { get; set; }
		
		[HttpGet]
		[Authorize(Roles = AppConstants.Workshop)]
		public async Task<PeopleEntity> GetProfile()
		{
			return await PeopleBusiness.GetFirstByFilterAsync(new PeopleFilter { Key = UserKey, RoleType = RoleType.Workshop, LoadDetails = true });
		}

		[HttpPost]
		[Authorize(Roles = AppConstants.Workshop)]
		public async Task<Execute<PeopleEntity>> SetProfile([FromBody] PeopleEntity entity)
		{
			return await PeopleBusiness.SaveAsync(entity);
		}

		[HttpGet("address")]
		[Authorize(Roles = AppConstants.Workshop)]
		public async Task<List<AddressesEntity>> GetAddresses()
		{
			return await AddressesBusiness.GetByFilterAsync(new AddressesFilter { IdPerson = UserKey });
		}

		[HttpPost("address")]
		[Authorize(Roles = AppConstants.Workshop)]
		public async Task<Execute<AddressesEntity>> SetAddress([FromBody] AddressesEntity entity)
		{
			entity.IdPerson = UserKey;
			return await AddressesBusiness.SaveAsync(entity);
		}

		[HttpGet("address/{id}")]
		[Authorize(Roles = AppConstants.Workshop)]
		public async Task<AddressesEntity> GetAddress(Guid id)
		{
			return await AddressesBusiness.GetFirstByFilterAsync(new AddressesFilter { IdPerson = UserKey, Key = id });
		}

		[HttpGet("workshopservice")]
		[Authorize(Roles = AppConstants.Workshop)]
		public async Task<List<WorkshopServicesEntity>> GetWorkshopServices()
		{
			return await WorkshopServicesBusiness.GetByFilterAsync(new WorkshopServicesFilter { IdWorkshop = UserKey });
		}

		[HttpGet("service/{id}")]
		[Authorize(Roles = AppConstants.Workshop)]
		public async Task<ServicesEntity> GetService(Guid id)
		{
			return await ServicesBusiness.GetFirstByFilterAsync(new ServicesFilter { IdService = UserKey, Key = id });
		}




	}
}
