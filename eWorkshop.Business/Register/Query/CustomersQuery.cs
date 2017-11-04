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
    public class CustomersQuery: SpecificationQuery<Customers, CustomersFilter>
    {
        public override IQueryable<Customers> Build(IQueryable<Customers> source, CustomersFilter filter)
        {
            var spefications = NewSpecificationList()
                .And(e => e.IdCustomer == filter.Key, f => f.Key.HasValue)
                .And(e => filter.Keys.Contains(e.IdCustomer), f => f.Keys.IsValidList())
                .OrderBy(e => e.IdCustomer)
                .Take(filter.PageNumber, filter.PageSize);

            return CheckSpecifications(spefications, source, filter);
        }
    }
}
