/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Service
{
	public partial class AppointmentsEntity: EntityBase
	{
		public Guid IdAppointment { get; set; }

		public Guid IdWorkshop { get; set; }

		public Guid IdCar { get; set; }

		public DateTime AppointmentDate { get; set; }

		public int Status { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ChangeDate { get; set; }

		public DateTime Date { get; set; }


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdAppointment;
			}
			set
			{
				IdAppointment = value;
			}
		}
	}
}
