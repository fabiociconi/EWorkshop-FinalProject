using eWorkshop.Entity.Service;
using System;
using XCommon.Application.Executes;
using XCommon.Patterns.Specification.Validation;
using XCommon.Patterns.Specification.Validation.Extensions;

namespace eWorkshop.Business.Service.Validate
{
	public class AppointmentsValidate: SpecificationValidation<AppointmentsEntity>
	{
		public override bool IsSatisfiedBy(AppointmentsEntity entity, Execute execute)
		{
			var spefications = NewSpecificationList()
				.AndIsValid(e => e.Key != Guid.Empty, "Default key isn't valid");

			return CheckSpecifications(spefications, entity, execute);
		}
	}
}
