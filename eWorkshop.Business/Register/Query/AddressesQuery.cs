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
	public class AddressesQuery: SpecificationQuery<Addresses, AddressesFilter>
	{
		public override IQueryable<Addresses> Build(IQueryable<Addresses> source, AddressesFilter filter)
		{
			var spefications = NewSpecificationList()
				.And(e => e.IdAddress == filter.Key, f => f.Key.HasValue)
				.And(e => filter.Keys.Contains(e.IdAddress), f => f.Keys.IsValidList())
				.OrderBy(e => e.IdAddress)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
