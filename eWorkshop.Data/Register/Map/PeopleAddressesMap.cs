/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
    internal class PeopleAddressesMap
    {
        internal static void Map(ModelBuilder modelBuilder, bool unitTest)
        {
            modelBuilder.Entity<PeopleAddresses>(entity =>
            {
                entity.HasKey(e => e.IdAddress);

                if (!unitTest)
                    entity.ToTable("PeopleAddresses", "Register");
                else
                    entity.ToTable("RegisterPeopleAddresses");

                entity.Property(e => e.IdAddress)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPerson)
                    .IsRequired();

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Type)
                    .IsRequired();

                entity.Property(e => e.Longitude)
                    .IsRequired();

                entity.Property(e => e.Latitude)
                    .IsRequired();

                entity
                    .HasOne(d => d.People)
                    .WithMany(p => p.PeopleAddresses)
                    .HasForeignKey(d => d.IdPerson);

            });
        }
    }
}
