/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Data.Register;
using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Service
{
	public class Services
	{
		public Guid IdService { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }

		public virtual ICollection<AppointmentsServices> AppointmentsServices { get; set; }

		public virtual ICollection<WorkshopServices> WorkshopServices { get; set; }

	}
}
