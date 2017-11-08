using  XCommon.Patterns.Repository;
using eWorkshop.Data;
using eWorkshop.Data.Service;
using eWorkshop.Entity.Service;
using eWorkshop.Entity.Service.Filter;
using System;

namespace eWorkshop.Business.Service
{
	public class AppointmentsServicesBusiness: RepositoryEFBase<AppointmentsServicesEntity, AppointmentsServicesFilter, AppointmentsServices, eWorkConext>
	{
	}
}
