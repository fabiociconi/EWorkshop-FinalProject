using System;
using System.Collections.Generic;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register.Filter
{
	public class AddressesFilter: FilterBase
	{
		public AddressesFilter()
		{
			IdPeople = new List<Guid>();
		}

		public Guid? IdPerson { get; set; }

		public List<Guid> IdPeople { get; set; }
	}
}
