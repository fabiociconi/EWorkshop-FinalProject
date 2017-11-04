using System;
using System.Runtime.Serialization;
using eWorkshop.Entity.Enum;

namespace eWorkshop.Entity.Register
{
	public class TokenEntity
	{
		public string Token { get; set; }

		public Guid IdPerson { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		[IgnoreDataMember]
		public RoleType RoleType { get; set; }
	}
}
