using eWorkshop.Data.Register;
using eWorkshop.Entity.Register.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using XCommon.Extensions.Checks;
using XCommon.Extensions.String;
using XCommon.Patterns.Specification.Query;
using XCommon.Patterns.Specification.Query.Extensions;

namespace eWorkshop.Business.Register.Query
{
	public class WorkshopServicesQuery: SpecificationQuery<WorkshopServices, WorkshopServicesFilter>
	{
		public override IQueryable<WorkshopServices> Build(IQueryable<WorkshopServices> source, WorkshopServicesFilter filter)
		{
			var spefications = NewSpecificationList()
				.And(e => e.IdWorkshopService == filter.Key, f => f.Key.HasValue)
				.And(e => filter.Keys.Contains(e.IdWorkshopService), f => f.Keys.IsValidList())
				.OrderBy(e => e.IdWorkshopService)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
