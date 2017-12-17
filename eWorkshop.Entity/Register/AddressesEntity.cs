using System;
using System.Collections.Generic;
using System.Text;

namespace eWorkshop.Entity.Register
{
    public partial class AddressesEntity
    {
		public double? Distance { get; set; } = -1;

		public string Name
		{
			get
			{
				return $"{StreetNumber}, {Street}";
			}
		}
	}
}
