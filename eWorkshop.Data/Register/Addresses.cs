/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Data.Service;
using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Register
{
	public class Addresses
	{
		public Guid IdAddress { get; set; }

		public Guid IdPerson { get; set; }

		public string Street { get; set; }

		public string StreetNumber { get; set; }

		public string City { get; set; }

		public string PostalCode { get; set; }

		public int Type { get; set; }

		public decimal Longitude { get; set; }

		public decimal Latitude { get; set; }

		public string Province { get; set; }

		public string Country { get; set; }

		public virtual People People { get; set; }

		public virtual ICollection<Appointments> Appointments { get; set; }

	}
}
