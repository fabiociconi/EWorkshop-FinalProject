using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using eWorkshop.Business.Register;
using eWorkshop.Entity.Enum;
using eWorkshop.Entity.Register;
using eWorkshop.Entity.Register.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using XCommon.Application.Executes;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Web.Controllers
{
	[Route("api/[controller]")]
	public class CustomerController : BaseController
	{
		[Inject]
		private PeopleBusiness PeopleBusiness { get; set; }

		[Inject]
		private AddressesBusiness AddressesBusiness { get; set; }

		[Inject]
		private CarsBusiness CarsBusiness { get; set; }

		[Inject]
		private WorkshopsBusiness WorkshopsBusiness { get; set; }

		[HttpGet]
		public async Task<PeopleEntity> GetProfile()
		{
			return await PeopleBusiness.GetFirstByFilterAsync(new PeopleFilter { Key = UserKey, RoleType = RoleType.Customer, LoadDetails = true });
		}

		[HttpPost]
		public async Task<Execute<PeopleEntity>> SetProfile([FromBody] PeopleEntity entity)
		{
			return await PeopleBusiness.SaveAsync(entity);
		}

		[HttpGet("address")]
		public async Task<List<AddressesEntity>> GetAddresses()
		{
			return await AddressesBusiness.GetByFilterAsync(new AddressesFilter { IdPerson = UserKey });
		}

		[HttpPost("address")]
		public async Task<Execute<AddressesEntity>> SetAddress([FromBody] AddressesEntity entity)
		{
			entity.IdPerson = UserKey;
			return await AddressesBusiness.SaveAsync(entity);
		}

		[HttpGet("address/{id}")]
		public async Task<AddressesEntity> GetAddress(Guid id)
		{
			return await AddressesBusiness.GetFirstByFilterAsync(new AddressesFilter { IdPerson = UserKey, Key = id });
		}

		[HttpGet("car")]
		public async Task<List<CarsEntity>> GetCars()
		{
			return await CarsBusiness.GetByFilterAsync(new CarsFilter { IdPerson = UserKey });
		}

		[HttpPost("car")]
		public async Task<Execute<CarsEntity>> SetCar([FromBody] CarsEntity entity)
		{
			entity.IdPerson = UserKey;
			return await CarsBusiness.SaveAsync(entity);
		}

		[HttpGet("car/{id}")]
		public async Task<CarsEntity> GetCar(Guid id)
		{
			return await CarsBusiness.GetFirstByFilterAsync(new CarsFilter { IdPerson = UserKey, Key = id });
		}

		[HttpPost("search")]
		public async Task<List<WorkshopsEntity>> Search([FromBody] WorkshopsFilter filter)
		{
			return await WorkshopsBusiness.GetByFilterAsync(filter);
		}
	}
}
