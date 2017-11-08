/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using System;
using System.Runtime.Serialization;
using XCommon.Patterns.Repository.Entity;

namespace eWorkshop.Entity.Register
{
	public partial class PeopleEntity: EntityBase
	{
		public Guid IdPerson { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Telephone { get; set; }

		public string Email { get; set; }

		public DateTime CreateDate { get; set; }

		public DateTime ChangeDate { get; set; }


		[IgnoreDataMember]
		public override Guid Key
		{
			get
			{
				return IdPerson;
			}
			set
			{
				IdPerson = value;
			}
		}
	}
}
