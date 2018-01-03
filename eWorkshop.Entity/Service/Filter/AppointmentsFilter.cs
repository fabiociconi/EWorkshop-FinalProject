using System;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Service.Filter
{
	public class AppointmentsFilter: FilterBase
	{
		public Guid? IdCar { get; set; }

		public Guid? IdPerson { get; set; }

		public Guid? IdWorkshop { get; set; }

		public DateTime? StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public int? Status { get; set; }
	}
}
