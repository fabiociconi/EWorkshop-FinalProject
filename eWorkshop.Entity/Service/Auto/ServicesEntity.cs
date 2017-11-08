/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Service
{
	public partial class ServicesEntity: EntityBase
	{
		public Guid IdService { get; set; }

		public string Name { get; set; }

		public string Description { get; set; }


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdService;
			}
			set
			{
				IdService = value;
			}
		}
	}
}
