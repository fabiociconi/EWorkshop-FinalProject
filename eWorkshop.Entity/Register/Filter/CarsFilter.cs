using System;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register.Filter
{
	public class CarsFilter: FilterBase
	{
		public Guid? IdPerson { get; set; }
	}
}
