using eWorkshop.Entity.Util;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register.Filter
{
	public class WorkshopsFilter: FilterBase
    {
		public string Name { get; set; }

		public string ServiceName { get; set; }

		public string Street { get; set; }

		public string City { get; set; }

		public string Province { get; set; }

		public double? ClientLatitude { get; set; }

		public double? ClientLongitude { get; set; }

		public int MaximumDistance { get; set; }
	}
}
