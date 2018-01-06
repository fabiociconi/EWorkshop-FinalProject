using System;
using System.Collections.Generic;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Service.Filter
{
	public class AppointmentsServicesFilter: FilterBase
	{
		public AppointmentsServicesFilter()
		{
			IdAppointments = new List<Guid>();
		}

		public Guid? IdAppointment { get; set; }

		public List<Guid> IdAppointments { get; set; }
	}
}
