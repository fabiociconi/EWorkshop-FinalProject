using eWorkshop.Data.Service;
using eWorkshop.Entity.Service.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using XCommon.Extensions.Checks;
using XCommon.Extensions.String;
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
				.OrderBy(e => e.IdAppointment)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
