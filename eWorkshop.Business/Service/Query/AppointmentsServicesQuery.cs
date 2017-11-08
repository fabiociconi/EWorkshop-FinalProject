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
	public class AppointmentsServicesQuery: SpecificationQuery<AppointmentsServices, AppointmentsServicesFilter>
	{
		public override IQueryable<AppointmentsServices> Build(IQueryable<AppointmentsServices> source, AppointmentsServicesFilter filter)
		{
			var spefications = NewSpecificationList()
				.And(e => e.IdAppointmentService == filter.Key, f => f.Key.HasValue)
				.And(e => filter.Keys.Contains(e.IdAppointmentService), f => f.Keys.IsValidList())
				.OrderBy(e => e.IdAppointmentService)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
