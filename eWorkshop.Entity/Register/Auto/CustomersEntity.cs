/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register
{
	public partial class CustomersEntity: EntityBase
	{
		public Guid IdCustomer { get; set; }

		public Guid IdPerson { get; set; }

		public DateTime? Birthday { get; set; }


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdCustomer;
			}
			set
			{
				IdCustomer = value;
			}
		}
	}
}
