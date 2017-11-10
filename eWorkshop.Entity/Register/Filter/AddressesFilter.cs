using System;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register.Filter
{
	public class AddressesFilter: FilterBase
	{
		public Guid? IdPerson { get; set; }
	}
}
