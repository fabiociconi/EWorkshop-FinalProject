/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Entity.Enum;
using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Register
{
	public class Users
	{
		public Guid IdUser { get; set; }

		public Guid IdPerson { get; set; }

		public string Password { get; set; }

		public RoleType Role { get; set; }

		public virtual People People { get; set; }

	}
}
