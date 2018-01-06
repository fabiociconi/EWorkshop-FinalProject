using System.Collections.Generic;

namespace eWorkshop.Entity.Register
{
	public partial class WorkshopsEntity
    {
		public WorkshopsEntity()
		{
			Addresses = new List<AddressesEntity>();
			Services = new List<WorkshopServicesEntity>();
		}

		public object Person { get; set; }

		public List<AddressesEntity> Addresses { get; set; }

		public List<WorkshopServicesEntity> Services { get; set; }
	}
}
