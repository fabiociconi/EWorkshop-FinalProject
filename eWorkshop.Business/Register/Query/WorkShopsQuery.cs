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
    public class WorkshopsQuery: SpecificationQuery<Workshops, WorkshopsFilter>
    {
        public override IQueryable<Workshops> Build(IQueryable<Workshops> source, WorkshopsFilter filter)
        {
            var spefications = NewSpecificationList()
                .And(e => e.IdWorkshop == filter.Key, f => f.Key.HasValue)
                .And(e => filter.Keys.Contains(e.IdWorkshop), f => f.Keys.IsValidList())
				.And(e => e.People.FirstName.Contains(filter.Name), f => f.Name.IsNotEmpty())
				.And(e => e.People.Addresses.Any(a => a.Street.Contains(filter.Street)), f => f.Street.IsNotEmpty())
				.And(e => e.People.Addresses.Any(a => a.Province.Contains(filter.Province)), f => f.Province.IsNotEmpty())
				.And(e => e.People.Addresses.Any(a => a.City.Contains(filter.City)), f => f.City.IsNotEmpty())
				.And(e => e.WorkshopServices.Any(s => s.Services.Name.Contains(filter.Name)), f => f.ServiceName.IsNotEmpty())
				.OrderBy(e => e.IdWorkshop)
                .Take(filter.PageNumber, filter.PageSize);

            return CheckSpecifications(spefications, source, filter);
        }
    }
}
