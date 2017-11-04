using System;
using eWorkshop.Entity.Enum;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register.Filter
{
    public class PeopleFilter: FilterBase
    {
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Email { get; set; }

		public string Telephone { get; set; }

		public RoleType RoleType { get; set; }
	}
}
