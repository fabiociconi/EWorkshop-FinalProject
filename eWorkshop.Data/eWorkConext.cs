/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Data.Register;
using eWorkshop.Data.Register.Map;
using eWorkshop.Data.Service;
using eWorkshop.Data.Service.Map;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using XCommon.Application;
using XCommon.Patterns.Ioc;

namespace eWorkshop.Data
{
	public class eWorkConext: DbContext
	{

		private IApplicationSettings AppSettings => Kernel.Resolve<IApplicationSettings>();

		public DbSet<Addresses> Addresses { get; set; }

		public DbSet<Cars> Cars { get; set; }

		public DbSet<CarsHistories> CarsHistories { get; set; }

		public DbSet<Customers> Customers { get; set; }

		public DbSet<People> People { get; set; }

		public DbSet<Users> Users { get; set; }

		public DbSet<Workshops> Workshops { get; set; }

		public DbSet<WorkshopServices> WorkshopServices { get; set; }

		public DbSet<Appointments> Appointments { get; set; }

		public DbSet<AppointmentsRatings> AppointmentsRatings { get; set; }

		public DbSet<AppointmentsServices> AppointmentsServices { get; set; }

		public DbSet<Services> Services { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			if (AppSettings.UnitTest)
			{
				options
					.UseInMemoryDatabase("eWorkConext")
					.ConfigureWarnings(config => config.Ignore(InMemoryEventId.TransactionIgnoredWarning));

				return;
			}

			options.UseSqlServer(AppSettings.DataBaseConnectionString);

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

			AddressesMap.Map(modelBuilder, AppSettings.UnitTest);
			CarsMap.Map(modelBuilder, AppSettings.UnitTest);
			CarsHistoriesMap.Map(modelBuilder, AppSettings.UnitTest);
			CustomersMap.Map(modelBuilder, AppSettings.UnitTest);
			PeopleMap.Map(modelBuilder, AppSettings.UnitTest);
			UsersMap.Map(modelBuilder, AppSettings.UnitTest);
			WorkshopsMap.Map(modelBuilder, AppSettings.UnitTest);
			WorkshopServicesMap.Map(modelBuilder, AppSettings.UnitTest);
			AppointmentsMap.Map(modelBuilder, AppSettings.UnitTest);
			AppointmentsRatingsMap.Map(modelBuilder, AppSettings.UnitTest);
			AppointmentsServicesMap.Map(modelBuilder, AppSettings.UnitTest);
			ServicesMap.Map(modelBuilder, AppSettings.UnitTest);
		}
	}
}
