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
	[Authorize(Roles = AppConstants.Workshop)]
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
		private AppointmentsBusiness AppointmentsBusiness { get; set; }

		[HttpGet]
		public async Task<PeopleEntity> GetProfile()
		{
			return await PeopleBusiness.GetFirstByFilterAsync(new PeopleFilter { Key = UserKey, RoleType = RoleType.Workshop, LoadDetails = true });
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

		[HttpGet("workshopservice")]
		public async Task<List<WorkshopServicesEntity>> GetWorkshopServices()
		{
			return await WorkshopServicesBusiness.GetByFilterAsync(new WorkshopServicesFilter { IdWorkshop = UserKey });
		}

		[HttpGet("workshopservice/{id}")]
		public async Task<WorkshopServicesEntity> GetWorkshopService(Guid id)
		{
			return await WorkshopServicesBusiness.GetFirstByFilterAsync(new WorkshopServicesFilter { IdWorkshopService = UserKey, Key = id });
		}

		[HttpPost("workshopservice")]
		public async Task<Execute<WorkshopServicesEntity>> SetWorkshopService([FromBody] WorkshopServicesEntity entity)
		{
			entity.IdWorkshop = UserKey;
			return await WorkshopServicesBusiness.SaveAsync(entity);
		}

		[HttpGet("appointment")]
		public async Task<List<AppointmentsEntity>> GetAppointments()
		{
			return await AppointmentsBusiness.GetByFilterAsync(new AppointmentsFilter { IdWorkshop = UserKey });
		}

		[HttpGet("appointment/{id}")]
		public async Task<AppointmentsEntity> GetAppointment(Guid id)
		{
			return await AppointmentsBusiness.GetFirstByFilterAsync(new AppointmentsFilter { IdWorkshop = UserKey, Key = id });
		}

		[HttpPost("appointment")]
		public async Task<Execute<AppointmentsEntity>> SetAppointment([FromBody] AppointmentsEntity entity)
		{
			return await AppointmentsBusiness.SaveAsync(entity);
		}
	}
}
