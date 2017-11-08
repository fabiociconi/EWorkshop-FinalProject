/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
	internal class CarsMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<Cars>(entity =>
			{
				entity.HasKey(e => e.IdCar);

				if (!unitTest)
					entity.ToTable("Cars", "Register");
				else
					entity.ToTable("RegisterCars");

				entity.Property(e => e.IdCar)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.IdPerson)
					.IsRequired();

				entity.Property(e => e.Brand)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Color)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Year)
					.IsRequired();

				entity.Property(e => e.Trasmission)
					.IsRequired();

				entity.Property(e => e.LicensePlate)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.FuelType)
					.IsRequired();

				entity.Property(e => e.CreateDate)
					.IsRequired();

				entity
					.HasOne(d => d.People)
					.WithMany(p => p.Cars)
					.HasForeignKey(d => d.IdPerson);

			});
		}
	}
}
