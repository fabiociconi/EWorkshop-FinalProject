using System;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register.Filter
{
	public class WorkshopServicesFilter: FilterBase
	{
		public Guid? IdWorkshop { get; set; }
	}
}
