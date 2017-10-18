using eWorkshop.Data.Sample;
using eWorkshop.Entity.Sample.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using XCommon.Extensions.Checks;
using XCommon.Extensions.String;
using XCommon.Patterns.Specification.Query;
using XCommon.Patterns.Specification.Query.Extensions;

namespace eWorkshop.Business.Sample.Query
{
    public class SampleTableQuery: SpecificationQuery<SampleTable, SampleTableFilter>
    {
        public override IQueryable<SampleTable> Build(IQueryable<SampleTable> source, SampleTableFilter filter)
        {
            var spefications = NewSpecificationList()
                .And(e => e.IdSample == filter.Key, f => f.Key.HasValue)
                .And(e => filter.Keys.Contains(e.IdSample), f => f.Keys.IsValidList())
                .OrderBy(e => e.IdSample)
                .Take(filter.PageNumber, filter.PageSize);

            return CheckSpecifications(spefications, source, filter);
        }
    }
}
