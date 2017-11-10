using eWorkshop.Business.Register;
using eWorkshop.Business.Service;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Business.Factory
{
    public partial class Register
    {
        public static void RegisterCustom(bool unitTest)
        {
			Kernel.Map<AddressesBusiness>().To<AddressesBusiness>();
			Kernel.Map<CarsBusiness>().To<CarsBusiness>();
			Kernel.Map<CarsHistoriesBusiness>().To<CarsHistoriesBusiness>();
			Kernel.Map<CustomersBusiness>().To<CustomersBusiness>();
			Kernel.Map<PeopleBusiness>().To<PeopleBusiness>();
			Kernel.Map<UsersBusiness>().To<UsersBusiness>();
			Kernel.Map<WorkshopsBusiness>().To<WorkshopsBusiness>();
			Kernel.Map<WorkshopServicesBusiness>().To<WorkshopServicesBusiness>();

			Kernel.Map<AppointmentsBusiness>().To<AppointmentsBusiness>();
			Kernel.Map<AppointmentsRatingsBusiness>().To<AppointmentsRatingsBusiness>();
			Kernel.Map<AppointmentsServicesBusiness>().To<AppointmentsServicesBusiness>();
			Kernel.Map<ServicesBusiness>().To<ServicesBusiness>();
		}
    }
}
