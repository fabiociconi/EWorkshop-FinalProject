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
	public class AppointmentsRatingsQuery: SpecificationQuery<AppointmentsRatings, AppointmentsRatingsFilter>
	{
		public override IQueryable<AppointmentsRatings> Build(IQueryable<AppointmentsRatings> source, AppointmentsRatingsFilter filter)
		{
			var spefications = NewSpecificationList()
				.And(e => e.IdAppointmentRating == filter.Key, f => f.Key.HasValue)
				.And(e => filter.Keys.Contains(e.IdAppointmentRating), f => f.Keys.IsValidList())
				.OrderBy(e => e.IdAppointmentRating)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
