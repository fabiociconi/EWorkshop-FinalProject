/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Sample
{
    public partial class SampleTableEntity: EntityBase
    {
        public Guid IdSample { get; set; }

        public string Value { get; set; }


        [IgnoreDataMember]
        public override Guid Key
        {
            get
            {
                return IdSample;
            }
            set
            {
                IdSample = value;
            }
        }
    }
}
