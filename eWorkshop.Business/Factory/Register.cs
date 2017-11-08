using eWorkshop.Business.Register;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Business.Factory
{
    public partial class Register
    {
        public static void RegisterCustom(bool unitTest)
        {
			Kernel.Map<CustomersBusiness>().To<CustomersBusiness>();
			Kernel.Map<PeopleBusiness>().To<PeopleBusiness>();
			Kernel.Map<UsersBusiness>().To<UsersBusiness>();
			Kernel.Map<WorkshopsBusiness>().To<WorkshopsBusiness>();
		}
    }
}
