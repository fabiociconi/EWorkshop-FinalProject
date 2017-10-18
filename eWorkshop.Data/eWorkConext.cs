/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using eWorkshop.Data.Sample;
using eWorkshop.Data.Sample.Map;
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

        public DbSet<SampleTable> SampleTable { get; set; }

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

            SampleTableMap.Map(modelBuilder, AppSettings.UnitTest);
        }
    }
}
