using System;
using System.Threading.Tasks;
using Plugin.Geolocator;

namespace MyWeatherApp.Services
{
	public class LocalizationSerivce
	{
		#region Properties
		public double latitude;
		public double longitude;
		#endregion

		#region Methods
		public async Task<Plugin.Geolocator.Abstractions.Position> GetCurrentLocation()
		{
			var locator = CrossGeolocator.Current;
			var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

			latitude = position.Latitude;
			longitude = position.Longitude;

			return position;
		}
		#endregion
	}
}
