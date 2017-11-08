/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Service.Map
{
	internal class AppointmentsServicesMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<AppointmentsServices>(entity =>
			{
				entity.HasKey(e => e.IdAppointmentService);

				if (!unitTest)
					entity.ToTable("AppointmentsServices", "Service");
				else
					entity.ToTable("ServiceAppointmentsServices");

				entity.Property(e => e.IdAppointmentService)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.IdAppointment)
					.IsRequired();

				entity.Property(e => e.IdService)
					.IsRequired();

				entity.Property(e => e.Price)
					.IsRequired();

				entity
					.HasOne(d => d.Appointments)
					.WithMany(p => p.AppointmentsServices)
					.HasForeignKey(d => d.IdAppointment);

				entity
					.HasOne(d => d.Services)
					.WithMany(p => p.AppointmentsServices)
					.HasForeignKey(d => d.IdService);

			});
		}
	}
}
