/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Service
{
	public class AppointmentsServices
	{
		public Guid IdAppointmentService { get; set; }

		public Guid IdAppointment { get; set; }

		public Guid IdService { get; set; }

		public decimal Price { get; set; }

		public virtual Appointments Appointments { get; set; }

		public virtual Services Services { get; set; }

	}
}
