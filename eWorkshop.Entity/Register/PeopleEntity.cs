using eWorkshop.Entity.Enum;

namespace eWorkshop.Entity.Register
{
	public partial class PeopleEntity
    {
		public RoleType Role { get; set; }

		public CustomersEntity Customer { get; set; }

		public WorkshopsEntity Workshop { get; set; }
	}
}
