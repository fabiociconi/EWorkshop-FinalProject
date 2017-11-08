/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Service.Map
{
	internal class AppointmentsRatingsMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<AppointmentsRatings>(entity =>
			{
				entity.HasKey(e => e.IdAppointmentRating);

				if (!unitTest)
					entity.ToTable("AppointmentsRatings", "Service");
				else
					entity.ToTable("ServiceAppointmentsRatings");

				entity.Property(e => e.IdAppointmentRating)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.IdAppointment)
					.IsRequired();

				entity.Property(e => e.RateValue)
					.IsRequired();

				entity.Property(e => e.CreateDate)
					.IsRequired();

				entity.Property(e => e.ChangeDate)
					.IsRequired();

				entity.Property(e => e.Comments);

				entity
					.HasOne(d => d.Appointments)
					.WithMany(p => p.AppointmentsRatings)
					.HasForeignKey(d => d.IdAppointment);

			});
		}
	}
}
