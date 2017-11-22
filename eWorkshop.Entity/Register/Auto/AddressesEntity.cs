/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register
{
	public partial class AddressesEntity: EntityBase
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


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdAddress;
			}
			set
			{
				IdAddress = value;
			}
		}
	}
}
