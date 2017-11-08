/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Register
{
	public class People
	{
		public Guid IdPerson { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Telephone { get; set; }

		public string Email { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ChangeDate { get; set; }

		public virtual ICollection<Workshops> Workshops { get; set; }

		public virtual ICollection<Cars> Cars { get; set; }

		public virtual ICollection<Addresses> Addresses { get; set; }

		public virtual ICollection<Users> Users { get; set; }

		public virtual ICollection<Customers> Customers { get; set; }

	}
}
