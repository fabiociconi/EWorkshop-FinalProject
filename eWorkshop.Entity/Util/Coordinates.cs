namespace eWorkshop.Entity.Util
{
	public class Coordinates
	{
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public Coordinates()
		{

		}

		public Coordinates(double latitude, double longitude)
		{
			Latitude = latitude;
			Longitude = longitude;
		}
	}
}
