using eWorkshop.Entity.Register;
using System;
using XCommon.Application.Executes;
using XCommon.Patterns.Specification.Validation;
using XCommon.Patterns.Specification.Validation.Extensions;

namespace eWorkshop.Business.Register.Validate
{
	public class CarsValidate: SpecificationValidation<CarsEntity>
	{
		public override bool IsSatisfiedBy(CarsEntity entity, Execute execute)
		{
			var spefications = NewSpecificationList()
				.AndIsValid(e => e.Key != Guid.Empty, "Default key isn't valid");

			return CheckSpecifications(spefications, entity, execute);
		}
	}
}
