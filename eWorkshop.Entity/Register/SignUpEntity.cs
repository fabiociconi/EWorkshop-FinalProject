using eWorkshop.Entity.Enum;

namespace eWorkshop.Entity.Register
{
    public class SignUpEntity : PeopleEntity
    {
        public string Password { get; set; }

        public string PasswordConfirm { get; set; }

        public RoleType RoleType { get; set; }
    }
}
