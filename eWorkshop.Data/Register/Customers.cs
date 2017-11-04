/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Register
{
    public class Customers
    {
        public Guid IdCustomer { get; set; }

        public Guid IdPerson { get; set; }

        public virtual People People { get; set; }

    }
}
