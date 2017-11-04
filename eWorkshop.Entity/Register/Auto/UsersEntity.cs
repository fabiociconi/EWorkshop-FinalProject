/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Entity.Enum;
using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register
{
    public partial class UsersEntity: EntityBase
    {
        public Guid IdUser { get; set; }

        public Guid IdPerson { get; set; }

        public string Password { get; set; }

        public RoleType Role { get; set; }


        [IgnoreDataMember]
        public override Guid Key
        {
            get
            {
                return IdUser;
            }
            set
            {
                IdUser = value;
            }
        }
    }
}
