using System.Linq;
using eWorkshop.Data.Service;
using eWorkshop.Entity.Service.Filter;
using XCommon.Extensions.Checks;
using XCommon.Patterns.Specification.Query;
using XCommon.Patterns.Specification.Query.Extensions;

namespace eWorkshop.Business.Service.Query
{
	public class AppointmentsQuery: SpecificationQuery<Appointments, AppointmentsFilter>
	{
		public override IQueryable<Appointments> Build(IQueryable<Appointments> source, AppointmentsFilter filter)
		{
			var spefications = NewSpecificationList()
				.And(e => e.IdAppointment == filter.Key, f => f.Key.HasValue)
				.And(e => filter.Keys.Contains(e.IdAppointment), f => f.Keys.IsValidList())
				.And(e => e.IdCar == filter.IdCar, f => f.IdCar.HasValue)
				.And(e => e.Cars.IdPerson == filter.IdPerson, f => f.IdPerson.HasValue)
				.And(e => e.IdWorkshop == filter.IdWorkshop, f => f.IdWorkshop.HasValue)
				.And(e => e.AppointmentDate >= filter.StartDate, f => f.StartDate.HasValue)
				.And(e => e.AppointmentDate <= filter.EndDate, f => f.EndDate.HasValue)
				.And(e => e.Status == filter.Status, f => f.Status.HasValue)
				.OrderBy(e => e.IdAppointment)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
