using eWorkshop.Entity.Sample;
using System;
using XCommon.Application.Executes;
using XCommon.Patterns.Specification.Validation;
using XCommon.Patterns.Specification.Validation.Extensions;

namespace eWorkshop.Business.Sample.Validate
{
    public class SampleTableValidate: SpecificationValidation<SampleTableEntity>
    {
        public override bool IsSatisfiedBy(SampleTableEntity entity, Execute execute)
        {
            var spefications = NewSpecificationList()
                .AndIsValid(e => e.Key != Guid.Empty, "Default key isn't valid");

            return CheckSpecifications(spefications, entity, execute);
        }
    }
}
