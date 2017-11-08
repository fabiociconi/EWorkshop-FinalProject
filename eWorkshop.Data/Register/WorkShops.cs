/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Data.Service;
using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Register
{
	public class Workshops
	{
		public Guid IdWorkshop { get; set; }

		public Guid IdPerson { get; set; }

		public string Description { get; set; }

		public virtual People People { get; set; }

		public virtual ICollection<WorkshopServices> WorkshopServices { get; set; }

		public virtual ICollection<Appointments> Appointments { get; set; }

	}
}
