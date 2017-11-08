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
	public class CarsHistoriesQuery: SpecificationQuery<CarsHistories, CarsHistoriesFilter>
	{
		public override IQueryable<CarsHistories> Build(IQueryable<CarsHistories> source, CarsHistoriesFilter filter)
		{
			var spefications = NewSpecificationList()
				.And(e => e.IdCarReportHistory == filter.Key, f => f.Key.HasValue)
				.And(e => filter.Keys.Contains(e.IdCarReportHistory), f => f.Keys.IsValidList())
				.OrderBy(e => e.IdCarReportHistory)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
