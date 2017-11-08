using  XCommon.Patterns.Repository;
using eWorkshop.Data;
using eWorkshop.Data.Register;
using eWorkshop.Entity.Register;
using eWorkshop.Entity.Register.Filter;
using System;

namespace eWorkshop.Business.Register
{
	public class AddressesBusiness: RepositoryEFBase<AddressesEntity, AddressesFilter, Addresses, eWorkConext>
	{
	}
}
