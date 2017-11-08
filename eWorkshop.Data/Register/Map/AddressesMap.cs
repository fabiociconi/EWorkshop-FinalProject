/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
	internal class AddressesMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<Addresses>(entity =>
			{
				entity.HasKey(e => e.IdAddress);

				if (!unitTest)
					entity.ToTable("Addresses", "Register");
				else
					entity.ToTable("RegisterAddresses");

				entity.Property(e => e.IdAddress)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.IdPerson)
					.IsRequired();

				entity.Property(e => e.Street)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.StreetNumber)
					.IsRequired()
					.HasMaxLength(10);

				entity.Property(e => e.City)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.PostalCode)
					.IsRequired()
					.HasMaxLength(6);

				entity.Property(e => e.Type)
					.IsRequired();

				entity.Property(e => e.Longitude)
					.IsRequired();

				entity.Property(e => e.Latitude)
					.IsRequired();

				entity
					.HasOne(d => d.People)
					.WithMany(p => p.Addresses)
					.HasForeignKey(d => d.IdPerson);

			});
		}
	}
}
