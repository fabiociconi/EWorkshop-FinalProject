using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Entity.Register
{
    public partial class WorkshopsEntity
    {
		public WorkshopsEntity()
		{
			Addresses = new List<AddressesEntity>();
			Services = new List<WorkshopServicesEntity>();
		}

		public PeopleEntity Person { get; set; }

		public List<AddressesEntity> Addresses { get; set; }

		public List<WorkshopServicesEntity> Services { get; set; }
	}
}