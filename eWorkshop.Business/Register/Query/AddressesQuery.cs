using System.Linq;
using eWorkshop.Data.Register;
using eWorkshop.Entity.Register.Filter;
using XCommon.Extensions.Checks;
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
				.And(e => e.IdPerson == filter.IdPerson, f => f.IdPerson.HasValue)
				.OrderBy(e => e.IdAddress)
				.Take(filter.PageNumber, filter.PageSize);

			return CheckSpecifications(spefications, source, filter);
		}
	}
}
