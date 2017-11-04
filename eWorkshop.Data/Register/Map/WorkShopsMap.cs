/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
    internal class WorkShopsMap
    {
        internal static void Map(ModelBuilder modelBuilder, bool unitTest)
        {
            modelBuilder.Entity<WorkShops>(entity =>
            {
                entity.HasKey(e => e.IdWorkShop);

                if (!unitTest)
                    entity.ToTable("WorkShops", "Register");
                else
                    entity.ToTable("RegisterWorkShops");

                entity.Property(e => e.IdWorkShop)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPerson)
                    .IsRequired();

                entity.Property(e => e.Description);

                entity
                    .HasOne(d => d.People)
                    .WithMany(p => p.WorkShops)
                    .HasForeignKey(d => d.IdPerson);

            });
        }
    }
}
