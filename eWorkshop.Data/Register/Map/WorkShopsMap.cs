/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
	internal class WorkshopsMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<Workshops>(entity =>
			{
				entity.HasKey(e => e.IdWorkshop);

				if (!unitTest)
					entity.ToTable("Workshops", "Register");
				else
					entity.ToTable("RegisterWorkshops");

				entity.Property(e => e.IdWorkshop)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.IdPerson)
					.IsRequired();

				entity.Property(e => e.Description);

				entity
					.HasOne(d => d.People)
					.WithMany(p => p.Workshops)
					.HasForeignKey(d => d.IdPerson);

			});
		}
	}
}
