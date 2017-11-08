/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register
{
	public partial class CarsEntity: EntityBase
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


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdCar;
			}
			set
			{
				IdCar = value;
			}
		}
	}
}
