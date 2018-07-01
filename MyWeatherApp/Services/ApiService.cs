using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyWeatherApp.Classes;
using Newtonsoft.Json;

namespace MyWeatherApp.Services
{
    public class ApiService
    {
		private Forecast forecast;
		public bool SuccessConnection = false;

		public async Task<Forecast> GetForecast(string url)
		{
			var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://api.openweathermap.org");
            var response = await Client.GetAsync(url);

			if (response.IsSuccessStatusCode)
			{
				var results = await response.Content.ReadAsStringAsync();
				forecast = JsonConvert.DeserializeObject<Forecast>(results);
				SuccessConnection = true;
			}

			return forecast;
		}
	}
}
