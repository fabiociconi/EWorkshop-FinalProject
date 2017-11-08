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
	public class CarsQuery: SpecificationQuery<Cars, CarsFilter>
	{
		public override IQueryable<Cars> Build(IQueryable<Cars> source, CarsFilter filter)
		{
			var spefications = NewSpecificationList()
				.And(e => e.IdCar == filter.Key, f => f.Key.HasValue)
				.And(e => filter.Keys.Contains(e.IdCar), f => f.Keys.IsValidList())
				.OrderBy(e => e.IdCar)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
