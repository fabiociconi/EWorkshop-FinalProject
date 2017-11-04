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

        public virtual ICollection<PeopleAddresses> PeopleAddresses { get; set; }

        public virtual ICollection<Users> Users { get; set; }

        public virtual ICollection<Customers> Customers { get; set; }

        public virtual ICollection<WorkShops> WorkShops { get; set; }

    }
}
