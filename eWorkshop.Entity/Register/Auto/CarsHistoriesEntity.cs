/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register
{
	public partial class CarsHistoriesEntity: EntityBase
	{
		public Guid IdCarReportHistory { get; set; }

		public Guid IdCar { get; set; }

		public int Type { get; set; }

		public DateTime CreateDate { get; set; }

		public string Decription { get; set; }


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdCarReportHistory;
			}
			set
			{
				IdCarReportHistory = value;
			}
		}
	}
}
