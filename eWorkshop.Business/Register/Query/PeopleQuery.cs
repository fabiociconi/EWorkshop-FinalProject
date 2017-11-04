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
    public class PeopleQuery: SpecificationQuery<People, PeopleFilter>
    {
        public override IQueryable<People> Build(IQueryable<People> source, PeopleFilter filter)
        {
            var spefications = NewSpecificationList()
                .And(e => e.IdPerson == filter.Key, f => f.Key.HasValue)
				.And(e => e.FirstName.Contains(filter.FirstName), f => f.FirstName.IsNotEmpty())
				.And(e => e.LastName.Contains(filter.LastName), f => f.LastName.IsNotEmpty())
				.And(e => e.Email == filter.Email, f => f.Email.IsNotEmpty())
				.And(e => e.Telephone == filter.Telephone, f => f.Telephone.IsNotEmpty())
				.And(e => filter.Keys.Contains(e.IdPerson), f => f.Keys.IsValidList())
                .OrderBy(e => e.IdPerson)
                .Take(filter.PageNumber, filter.PageSize);

            return CheckSpecifications(spefications, source, filter);
        }
    }
}
