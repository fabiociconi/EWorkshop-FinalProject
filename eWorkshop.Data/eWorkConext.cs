/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Data.Register;
using eWorkshop.Data.Register.Map;
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

        public DbSet<Customers> Customers { get; set; }

        public DbSet<People> People { get; set; }

        public DbSet<PeopleAddresses> PeopleAddresses { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<WorkShops> WorkShops { get; set; }

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

            CustomersMap.Map(modelBuilder, AppSettings.UnitTest);
            PeopleMap.Map(modelBuilder, AppSettings.UnitTest);
            PeopleAddressesMap.Map(modelBuilder, AppSettings.UnitTest);
            UsersMap.Map(modelBuilder, AppSettings.UnitTest);
            WorkShopsMap.Map(modelBuilder, AppSettings.UnitTest);
        }
    }
}
