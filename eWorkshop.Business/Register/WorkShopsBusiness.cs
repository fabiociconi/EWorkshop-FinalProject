using System.Collections.Generic;
using System.Threading.Tasks;
using eWorkshop.Data;
using eWorkshop.Data.Register;
using eWorkshop.Entity.Register;
using eWorkshop.Entity.Register.Filter;
using XCommon.Patterns.Repository;
using eWorkshop.Entity.Util;
using XCommon.Patterns.Ioc;
using System.Linq;
using System;

namespace eWorkshop.Business.Register
{
	public class WorkshopsBusiness: RepositoryEFBase<WorkshopsEntity, WorkshopsFilter, Workshops, eWorkConext>
    {
		private PeopleBusiness PeopleBusiness => Kernel.Resolve<PeopleBusiness>();

		private AddressesBusiness AddressesBusiness => Kernel.Resolve<AddressesBusiness>();

		private WorkshopServicesBusiness WorkshopServicesBusiness => Kernel.Resolve<WorkshopServicesBusiness>();


		public async override Task<List<WorkshopsEntity>> GetByFilterAsync(WorkshopsFilter filter)
		{
			var result = await base.GetByFilterAsync(filter);

			if (!result.Any())
			{
				return result;
			}

			var idPeople = result.Select(c => c.IdPerson).ToList();

			var people = await PeopleBusiness.GetByFilterAsync(new PeopleFilter { Keys = idPeople });
			var addresses = await AddressesBusiness.GetByFilterAsync(new AddressesFilter { IdPeople = idPeople });
			var services = await WorkshopServicesBusiness.GetByFilterAsync(new WorkshopServicesFilter { IdWorkshops = idPeople });

			if (filter.ClientLongitude.HasValue && filter.ClientLatitude.HasValue && filter.MaximumDistance > 0)
			{
				addresses.ForEach(a => {
					a.Distance = new Coordinates(filter.ClientLatitude.Value, filter.ClientLongitude.Value)
						.DistanceTo(decimal.ToDouble(a.Latitude), decimal.ToDouble(a.Longitude));
				});

				addresses.RemoveAll(c => c.Distance > filter.MaximumDistance);
			}

			foreach (var item in result)
			{
				item.Person = people.FirstOrDefault(c => item.IdPerson == c.IdPerson);
				item.Addresses.AddRange(addresses.Where(c => item.IdPerson == c.IdPerson));
				item.Services.AddRange(services.Where(c => item.IdWorkshop == c.IdWorkshop));
			}

			result.RemoveAll(c => c.Addresses.Count <= 0);
			
			return result;
		}
	}
}
