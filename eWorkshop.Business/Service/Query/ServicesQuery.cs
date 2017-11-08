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
	public class ServicesQuery: SpecificationQuery<Services, ServicesFilter>
	{
		public override IQueryable<Services> Build(IQueryable<Services> source, ServicesFilter filter)
		{
			var spefications = NewSpecificationList()
				.And(e => e.IdService == filter.Key, f => f.Key.HasValue)
				.And(e => filter.Keys.Contains(e.IdService), f => f.Keys.IsValidList())
				.OrderBy(e => e.Name)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
