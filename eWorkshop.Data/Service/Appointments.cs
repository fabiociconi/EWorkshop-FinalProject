/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Data.Register;
using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Service
{
	public class Appointments
	{
		public Guid IdAppointment { get; set; }

		public Guid IdWorkshop { get; set; }

		public Guid IdCar { get; set; }

		public DateTime AppointmentDate { get; set; }

		public int Status { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ChangeDate { get; set; }

		public DateTime Date { get; set; }

		public virtual Workshops Workshops { get; set; }

		public virtual Cars Cars { get; set; }

		public virtual ICollection<AppointmentsServices> AppointmentsServices { get; set; }

		public virtual ICollection<AppointmentsRatings> AppointmentsRatings { get; set; }

	}
}
