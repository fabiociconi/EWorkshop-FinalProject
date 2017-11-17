using System;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Service.Filter
{
	public class ServicesFilter: FilterBase
	{
		public Guid? IdService { get; set; }
	}
}
