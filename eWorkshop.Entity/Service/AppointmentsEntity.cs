using System;
using System.Collections.Generic;
using System.Text;
using eWorkshop.Entity.Register;

namespace eWorkshop.Entity.Service
{
	public partial class AppointmentsEntity
	{
		public AppointmentsEntity()
		{
			Services = new List<AppointmentsServicesEntity>();
		}

		public PeopleEntity Workshop { get; set; }

		public PeopleEntity Customer { get; set; }

		public CarsEntity Car { get; set; }

		public AddressesEntity Address { get; set; }

		public List<AppointmentsServicesEntity> Services { get; set; }
	}
}
