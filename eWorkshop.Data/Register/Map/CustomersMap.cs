/***************************************** WARNING *****************************************/
/* Don't write any code in this file, because it will be rewritten on the next generation. */
/*******************************************************************************************/

using Microsoft.EntityFrameworkCore;
using System;

namespace eWorkshop.Data.Register.Map
{
	internal class CustomersMap
	{
		internal static void Map(ModelBuilder modelBuilder, bool unitTest)
		{
			modelBuilder.Entity<Customers>(entity =>
			{
				entity.HasKey(e => e.IdCustomer);

				if (!unitTest)
					entity.ToTable("Customers", "Register");
				else
					entity.ToTable("RegisterCustomers");

				entity.Property(e => e.IdCustomer)
					.IsRequired()
					.ValueGeneratedNever();

				entity.Property(e => e.IdPerson)
					.IsRequired();

				entity.Property(e => e.Birthday);

				entity
					.HasOne(d => d.People)
					.WithMany(p => p.Customers)
					.HasForeignKey(d => d.IdPerson);

			});
		}
	}
}
