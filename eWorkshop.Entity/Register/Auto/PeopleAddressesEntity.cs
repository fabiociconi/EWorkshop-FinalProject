/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Entity.Enum;
using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register
{
    public partial class PeopleAddressesEntity: EntityBase
    {
        public Guid IdAddress { get; set; }

        public Guid IdPerson { get; set; }

        public string Street { get; set; }

        public string City { get; set; }

        public string ZipCode { get; set; }

        public AddressType Type { get; set; }

        public decimal Longitude { get; set; }

        public decimal Latitude { get; set; }


        [IgnoreDataMember]
        public override Guid Key
        {
            get
            {
                return IdAddress;
            }
            set
            {
                IdAddress = value;
            }
        }
    }
}
