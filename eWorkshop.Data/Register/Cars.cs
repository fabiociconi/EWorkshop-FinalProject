/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Data.Service;
using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Register
{
	public class Cars
	{
		public Guid IdCar { get; set; }

		public Guid IdPerson { get; set; }

		public string Brand { get; set; }

		public string Color { get; set; }

		public int Year { get; set; }

		public int Trasmission { get; set; }

		public string LicensePlate { get; set; }

		public int FuelType { get; set; }

		public DateTime CreateDate { get; set; }

		public string Model { get; set; }

		public virtual People People { get; set; }

		public virtual ICollection<CarsHistories> CarsHistories { get; set; }

		public virtual ICollection<Appointments> Appointments { get; set; }

	}
}
