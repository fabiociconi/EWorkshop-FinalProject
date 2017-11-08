/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Data.Service;
using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Register
{
	public class WorkshopServices
	{
		public Guid IdWorkshopService { get; set; }

		public Guid IdWorkshop { get; set; }

		public Guid IdService { get; set; }

		public decimal Price { get; set; }

		public virtual Workshops Workshops { get; set; }

		public virtual Services Services { get; set; }

	}
}
