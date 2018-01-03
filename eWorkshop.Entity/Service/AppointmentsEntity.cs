using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Entity.Service
{
    public partial class AppointmentsEntity
    {
		public AppointmentsEntity()
		{
			Services = new List<AppointmentsServicesEntity>();
		}

		public List<AppointmentsServicesEntity> Services { get; set; }
	}
}
