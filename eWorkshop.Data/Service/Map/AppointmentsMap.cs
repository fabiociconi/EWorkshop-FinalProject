/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Service.Map
{
	internal class AppointmentsMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<Appointments>(entity =>
			{
				entity.HasKey(e => e.IdAppointment);

				if (!unitTest)
					entity.ToTable("Appointments", "Service");
				else
					entity.ToTable("ServiceAppointments");

				entity.Property(e => e.IdAppointment)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.IdWorkshop)
					.IsRequired();

				entity.Property(e => e.IdCar)
					.IsRequired();

				entity.Property(e => e.AppointmentDate)
					.IsRequired();

				entity.Property(e => e.Status)
					.IsRequired();

				entity.Property(e => e.CreateDate)
					.IsRequired();

				entity.Property(e => e.ChangeDate)
					.IsRequired();

				entity.Property(e => e.Date)
					.IsRequired();

				entity.Property(e => e.IdAddress)
					.IsRequired();

				entity
					.HasOne(d => d.Workshops)
					.WithMany(p => p.Appointments)
					.HasForeignKey(d => d.IdWorkshop);

				entity
					.HasOne(d => d.Cars)
					.WithMany(p => p.Appointments)
					.HasForeignKey(d => d.IdCar);

				entity
					.HasOne(d => d.Addresses)
					.WithMany(p => p.Appointments)
					.HasForeignKey(d => d.IdAddress);

			});
		}
	}
}
