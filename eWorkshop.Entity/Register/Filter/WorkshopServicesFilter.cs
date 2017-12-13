using System;
using System.Collections.Generic;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register.Filter
{
	public class WorkshopServicesFilter: FilterBase
	{
		public WorkshopServicesFilter()
		{
			IdWorkshops = new List<Guid>();
		}

		public Guid? IdWorkshop { get; set; }

		public List<Guid> IdWorkshops { get; set; }

		public Guid? IdWorkshopService { get; set; }
	}
}
