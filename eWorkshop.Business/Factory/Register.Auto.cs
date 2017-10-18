using eWorkshop.Business.Sample;
using eWorkshop.Business.Sample.Query;
using eWorkshop.Business.Sample.Validate;
using eWorkshop.Data.Sample;
using eWorkshop.Entity.Sample;
using eWorkshop.Entity.Sample.Filter;
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
            Kernel.Map<ISpecificationQuery<SampleTable, SampleTableFilter>>().To<SampleTableQuery>();
        }

        private static void RegisterValidate()
        {
            Kernel.Map<ISpecificationValidation<SampleTableEntity>>().To<SampleTableValidate>();
        }
    }
}
