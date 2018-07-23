using System;
using System.Net.Http;
using System.Threading.Tasks;
using MyWeatherApp.Classes;
using Newtonsoft.Json;
using Xamarin.Forms;

namespace MyWeatherApp.Services
{
    public class ApiService
    {
		private Forecast forecast;
		public bool SuccessConnection = false;
		InternetConnection internetConnection = new InternetConnection();
        

		public async Task<Forecast> GetForecast(string url)
		{
			var connection = await internetConnection.CheckConnection();
            if (!connection.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return null;
            }

			try
			{
				var Client = new HttpClient();
                Client.BaseAddress = new Uri("http://api.openweathermap.org");
                var response = await Client.GetAsync(url);

                if (response.IsSuccessStatusCode)
                {
                    var results = await response.Content.ReadAsStringAsync();
                    forecast = JsonConvert.DeserializeObject<Forecast>(results);
                    SuccessConnection = true;
                    return forecast;
                }
                else
                {
                    return null;
                }
			}
			catch (Exception ex)
			{
				return null;
			}
		}
	}
}