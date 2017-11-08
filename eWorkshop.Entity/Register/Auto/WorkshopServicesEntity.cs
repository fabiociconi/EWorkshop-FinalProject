/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register
{
	public partial class WorkshopServicesEntity: EntityBase
	{
		public Guid IdWorkshopService { get; set; }

		public Guid IdWorkshop { get; set; }

		public Guid IdService { get; set; }

		public decimal Price { get; set; }


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdWorkshopService;
			}
			set
			{
				IdWorkshopService = value;
			}
		}
	}
}
