using eWorkshop.Entity.Service;
using System;
using XCommon.Application.Executes;
using XCommon.Patterns.Specification.Validation;
using XCommon.Patterns.Specification.Validation.Extensions;

namespace eWorkshop.Business.Service.Validate
{
	public class AppointmentsRatingsValidate: SpecificationValidation<AppointmentsRatingsEntity>
	{
		public override bool IsSatisfiedBy(AppointmentsRatingsEntity entity, Execute execute)
		{
			var spefications = NewSpecificationList()
				.AndIsValid(e => e.Key != Guid.Empty, "Default key isn't valid");

			return CheckSpecifications(spefications, entity, execute);
		}
	}
}
