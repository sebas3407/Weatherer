using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace MyWeatherApp.Services
{
	public class LocalizationService
	{
		#region Properties
		public double latitude;
		public double longitude;
		#endregion

		#region Methods
		public async Task<Position> GetCurrentLocation()
		{
			Position position = null;
			try
            {
				var locator = CrossGeolocator.Current;

                if (locator.IsGeolocationEnabled)
                {
					position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));
					latitude = position.Latitude;
                    longitude = position.Longitude;
                }
            }
            catch (Exception e)
            {
                position = new Position() { Latitude = 0, Longitude = 0 };
            }

			return position;
		}
		#endregion
	}
}
