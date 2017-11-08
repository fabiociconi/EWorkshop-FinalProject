/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
	internal class CarsHistoriesMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<CarsHistories>(entity =>
			{
				entity.HasKey(e => e.IdCarReportHistory);

				if (!unitTest)
					entity.ToTable("CarsHistories", "Register");
				else
					entity.ToTable("RegisterCarsHistories");

				entity.Property(e => e.IdCarReportHistory)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.IdCar)
					.IsRequired();

				entity.Property(e => e.Type)
					.IsRequired();

				entity.Property(e => e.CreateDate)
					.IsRequired();

				entity.Property(e => e.Decription);

				entity
					.HasOne(d => d.Cars)
					.WithMany(p => p.CarsHistories)
					.HasForeignKey(d => d.IdCar);

			});
		}
	}
}
