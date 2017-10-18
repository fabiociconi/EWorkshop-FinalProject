/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Sample.Map
{
    internal class SampleTableMap
    {
        internal static void Map(ModelBuilder modelBuilder, bool unitTest)
        {
            modelBuilder.Entity<SampleTable>(entity =>
            {
                entity.HasKey(e => e.IdSample);

                if (!unitTest)
                    entity.ToTable("SampleTable", "Sample");
                else
                    entity.ToTable("SampleSampleTable");

                entity.Property(e => e.IdSample)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity.Property(e => e.Value);

            });
        }
    }
}
