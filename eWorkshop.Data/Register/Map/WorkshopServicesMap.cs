/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
	internal class WorkshopServicesMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<WorkshopServices>(entity =>
			{
				entity.HasKey(e => e.IdWorkshopService);

				if (!unitTest)
					entity.ToTable("WorkshopServices", "Register");
				else
					entity.ToTable("RegisterWorkshopServices");

				entity.Property(e => e.IdWorkshopService)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.IdWorkshop)
					.IsRequired();

				entity.Property(e => e.IdService)
					.IsRequired();

				entity.Property(e => e.Price)
					.IsRequired();

				entity
					.HasOne(d => d.Workshops)
					.WithMany(p => p.WorkshopServices)
					.HasForeignKey(d => d.IdWorkshop);

				entity
					.HasOne(d => d.Services)
					.WithMany(p => p.WorkshopServices)
					.HasForeignKey(d => d.IdService);

			});
		}
	}
}
