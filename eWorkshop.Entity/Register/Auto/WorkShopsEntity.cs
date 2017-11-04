/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register
{
    public partial class WorkShopsEntity: EntityBase
    {
        public Guid IdWorkShop { get; set; }

        public Guid IdPerson { get; set; }

        public string Description { get; set; }


        [IgnoreDataMember]
        public override Guid Key
        {
            get
            {
                return IdWorkShop;
            }
            set
            {
                IdWorkShop = value;
            }
        }
    }
}
