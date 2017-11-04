/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
    internal class PeopleMap
    {
        internal static void Map(ModelBuilder modelBuilder, bool unitTest)
        {
            modelBuilder.Entity<People>(entity =>
            {
                entity.HasKey(e => e.IdPerson);

                if (!unitTest)
                    entity.ToTable("People", "Register");
                else
                    entity.ToTable("RegisterPeople");

                entity.Property(e => e.IdPerson)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Telephone)
                    .HasMaxLength(200);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(200);

            });
        }
    }
}
