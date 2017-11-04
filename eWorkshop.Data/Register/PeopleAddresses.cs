/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Entity.Enum;
using System;
using System.Collections.Generic;

namespace eWorkshop.Data.Register
{
    public class PeopleAddresses
    {
        public Guid IdAddress { get; set; }

        public Guid IdPerson { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public AddressType Type { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }

        public virtual People People { get; set; }

    }
}
