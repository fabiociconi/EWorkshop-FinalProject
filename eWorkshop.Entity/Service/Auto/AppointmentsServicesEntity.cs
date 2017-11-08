/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Service
{
	public partial class AppointmentsServicesEntity: EntityBase
	{
		public Guid IdAppointmentService { get; set; }

		public Guid IdAppointment { get; set; }

		public Guid IdService { get; set; }

		public decimal Price { get; set; }


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdAppointmentService;
			}
			set
			{
				IdAppointmentService = value;
			}
		}
	}
}
