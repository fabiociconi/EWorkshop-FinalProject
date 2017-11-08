using eWorkshop.Business.Register;
using eWorkshop.Business.Register.Query;
using eWorkshop.Business.Register.Validate;
using eWorkshop.Business.Service;
using eWorkshop.Business.Service.Query;
using eWorkshop.Business.Service.Validate;
using eWorkshop.Data.Register;
using eWorkshop.Data.Service;
using eWorkshop.Entity.Register;
using eWorkshop.Entity.Register.Filter;
using eWorkshop.Entity.Service;
using eWorkshop.Entity.Service.Filter;
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
			Kernel.Map<ISpecificationQuery<Addresses, AddressesFilter>>().To<AddressesQuery>();
			Kernel.Map<ISpecificationQuery<Cars, CarsFilter>>().To<CarsQuery>();
			Kernel.Map<ISpecificationQuery<CarsHistories, CarsHistoriesFilter>>().To<CarsHistoriesQuery>();
			Kernel.Map<ISpecificationQuery<Customers, CustomersFilter>>().To<CustomersQuery>();
			Kernel.Map<ISpecificationQuery<People, PeopleFilter>>().To<PeopleQuery>();
			Kernel.Map<ISpecificationQuery<Users, UsersFilter>>().To<UsersQuery>();
			Kernel.Map<ISpecificationQuery<Workshops, WorkshopsFilter>>().To<WorkshopsQuery>();
			Kernel.Map<ISpecificationQuery<WorkshopServices, WorkshopServicesFilter>>().To<WorkshopServicesQuery>();
			Kernel.Map<ISpecificationQuery<Appointments, AppointmentsFilter>>().To<AppointmentsQuery>();
			Kernel.Map<ISpecificationQuery<AppointmentsRatings, AppointmentsRatingsFilter>>().To<AppointmentsRatingsQuery>();
			Kernel.Map<ISpecificationQuery<AppointmentsServices, AppointmentsServicesFilter>>().To<AppointmentsServicesQuery>();
			Kernel.Map<ISpecificationQuery<Services, ServicesFilter>>().To<ServicesQuery>();
		}

		private static void RegisterValidate()
		{
			Kernel.Map<ISpecificationValidation<AddressesEntity>>().To<AddressesValidate>();
			Kernel.Map<ISpecificationValidation<CarsEntity>>().To<CarsValidate>();
			Kernel.Map<ISpecificationValidation<CarsHistoriesEntity>>().To<CarsHistoriesValidate>();
			Kernel.Map<ISpecificationValidation<CustomersEntity>>().To<CustomersValidate>();
			Kernel.Map<ISpecificationValidation<PeopleEntity>>().To<PeopleValidate>();
			Kernel.Map<ISpecificationValidation<UsersEntity>>().To<UsersValidate>();
			Kernel.Map<ISpecificationValidation<WorkshopsEntity>>().To<WorkshopsValidate>();
			Kernel.Map<ISpecificationValidation<WorkshopServicesEntity>>().To<WorkshopServicesValidate>();
			Kernel.Map<ISpecificationValidation<AppointmentsEntity>>().To<AppointmentsValidate>();
			Kernel.Map<ISpecificationValidation<AppointmentsRatingsEntity>>().To<AppointmentsRatingsValidate>();
			Kernel.Map<ISpecificationValidation<AppointmentsServicesEntity>>().To<AppointmentsServicesValidate>();
			Kernel.Map<ISpecificationValidation<ServicesEntity>>().To<ServicesValidate>();
		}
	}
}
