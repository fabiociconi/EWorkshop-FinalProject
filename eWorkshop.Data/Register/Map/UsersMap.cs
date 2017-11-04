/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
    internal class UsersMap
    {
        internal static void Map(ModelBuilder modelBuilder, bool unitTest)
        {
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                if (!unitTest)
                    entity.ToTable("Users", "Register");
                else
                    entity.ToTable("RegisterUsers");

                entity.Property(e => e.IdUser)
                    .IsRequired()
                    .ValueGeneratedNever();

                entity.Property(e => e.IdPerson)
                    .IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Role)
                    .IsRequired();

                entity
                    .HasOne(d => d.People)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdPerson);

            });
        }
    }
}
