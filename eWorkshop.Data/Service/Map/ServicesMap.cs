/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Service.Map
{
	internal class ServicesMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<Services>(entity =>
			{
				entity.HasKey(e => e.IdService);

				if (!unitTest)
					entity.ToTable("Services", "Service");
				else
					entity.ToTable("ServiceServices");

				entity.Property(e => e.IdService)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.Name)
					.IsRequired()
					.HasMaxLength(50);

				entity.Property(e => e.Description)
					.IsRequired()
					.HasMaxLength(50);

			});
		}
	}
}
