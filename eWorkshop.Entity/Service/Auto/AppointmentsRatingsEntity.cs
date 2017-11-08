/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Service
{
	public partial class AppointmentsRatingsEntity: EntityBase
	{
		public Guid IdAppointmentRating { get; set; }

		public Guid IdAppointment { get; set; }

		public int RateValue { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ChangeDate { get; set; }

		public string Comments { get; set; }


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdAppointmentRating;
			}
			set
			{
				IdAppointmentRating = value;
			}
		}
	}
}
