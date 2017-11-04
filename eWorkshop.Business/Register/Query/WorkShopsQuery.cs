﻿using eWorkshop.Data.Register;
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
    public class WorkShopsQuery: SpecificationQuery<WorkShops, WorkShopsFilter>
    {
        public override IQueryable<WorkShops> Build(IQueryable<WorkShops> source, WorkShopsFilter filter)
        {
            var spefications = NewSpecificationList()
                .And(e => e.IdWorkShop == filter.Key, f => f.Key.HasValue)
                .And(e => filter.Keys.Contains(e.IdWorkShop), f => f.Keys.IsValidList())
                .OrderBy(e => e.IdWorkShop)
                .Take(filter.PageNumber, filter.PageSize);

            return CheckSpecifications(spefications, source, filter);
        }
    }
}
