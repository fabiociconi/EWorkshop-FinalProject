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
    public class UsersQuery: SpecificationQuery<Users, UsersFilter>
    {
        public override IQueryable<Users> Build(IQueryable<Users> source, UsersFilter filter)
        {
            var spefications = NewSpecificationList()
                .And(e => e.IdUser == filter.Key, f => f.Key.HasValue)
                .And(e => e.Password == filter.Password, f => f.Password.IsNotEmpty())
                .And(e => filter.Keys.Contains(e.IdUser), f => f.Keys.IsValidList())
                .OrderBy(e => e.IdUser)
                .Take(filter.PageNumber, filter.PageSize);

            return CheckSpecifications(spefications, source, filter);
        }
    }
}
