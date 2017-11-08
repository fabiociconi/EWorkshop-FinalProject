/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Service
{
	public class AppointmentsRatings
	{
		public Guid IdAppointmentRating { get; set; }

		public Guid IdAppointment { get; set; }

		public int RateValue { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ChangeDate { get; set; }

		public string Comments { get; set; }

		public virtual Appointments Appointments { get; set; }

	}
}
