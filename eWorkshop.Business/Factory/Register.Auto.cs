using eWorkshop.Business.Register;
using eWorkshop.Business.Register.Query;
using eWorkshop.Business.Register.Validate;
using eWorkshop.Data.Register;
using eWorkshop.Entity.Register;
using eWorkshop.Entity.Register.Filter;
using XCommon.Patterns.Ioc;
using XCommon.Patterns.Specification.Query;
using XCommon.Patterns.Specification.Validation;

namespace eWorkshop.Business.Factory
{
    public partial class Register
    {
        public static void Do(bool unitTest = false)
        {
            RegisterValidate();
            RegisterQuery();
            RegisterCustom(unitTest);
        }

        private static void RegisterQuery()
        {
            Kernel.Map<ISpecificationQuery<Customers, CustomersFilter>>().To<CustomersQuery>();
            Kernel.Map<ISpecificationQuery<People, PeopleFilter>>().To<PeopleQuery>();
            Kernel.Map<ISpecificationQuery<PeopleAddresses, PeopleAddressesFilter>>().To<PeopleAddressesQuery>();
            Kernel.Map<ISpecificationQuery<Users, UsersFilter>>().To<UsersQuery>();
            Kernel.Map<ISpecificationQuery<WorkShops, WorkShopsFilter>>().To<WorkShopsQuery>();
        }

        private static void RegisterValidate()
        {
            Kernel.Map<ISpecificationValidation<CustomersEntity>>().To<CustomersValidate>();
            Kernel.Map<ISpecificationValidation<PeopleEntity>>().To<PeopleValidate>();
            Kernel.Map<ISpecificationValidation<PeopleAddressesEntity>>().To<PeopleAddressesValidate>();
            Kernel.Map<ISpecificationValidation<UsersEntity>>().To<UsersValidate>();
            Kernel.Map<ISpecificationValidation<WorkShopsEntity>>().To<WorkShopsValidate>();
        }
    }
}
