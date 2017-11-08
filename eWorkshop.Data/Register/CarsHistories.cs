/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Register
{
	public class CarsHistories
	{
		public Guid IdCarReportHistory { get; set; }

		public Guid IdCar { get; set; }

		public int Type { get; set; }

		public DateTime CreateDate { get; set; }

		public string Decription { get; set; }

		public virtual Cars Cars { get; set; }

	}
}
