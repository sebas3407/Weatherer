using System;
using System.Net.Http;
using Newtonsoft.Json;
using MyWeatherApp.Classes;
using MyWeatherApp.ViewModels;

namespace MyWeatherApp.ViewModels
{
	public class HomeViewModel: BaseViewModel
	{
		#region Properties
		private Forecast forecast;
		private Country country;

		private String currentTime;
		public String CurrentTime
		{
			get { return currentTime; }
			set { SetValue(ref currentTime, value); }
		}

		private String city;
		public String City
		{
			get { return city; }
			set { SetValue(ref city, value); }
		}

		private String countryName;
		public String CountryName
		{
			get { return countryName; }
			set { SetValue(ref countryName, value); }
		}

		private String countryCode;
		public String CountryCode
		{
			get { return countryCode; }
			set { SetValue(ref countryCode, value); }
		}

		private string currentDate;
		public string CurrentDate
		{
			get { return currentDate; }
			set { SetValue(ref currentDate, value); }
		}

		private double temperature;
		public double Temperature
		{
			get { return temperature; }
			set { SetValue(ref temperature, value); }
		}

		private string humidity;
		public string Humidity
		{
			get { return humidity; }
			set { SetValue(ref humidity, value); }
		}

		private string wind;
		public string Wind
		{
			get { return wind; }
			set { SetValue(ref wind, value); }
		}

		private string description;
		public string Description
		{
			get { return description; }
			set { SetValue(ref description, value); }
		}

		private string clouds;
		public string Clouds
		{
			get { return clouds; }
			set { SetValue(ref clouds, value); }
		}

		private string pressure;
		public string Pressure
		{
			get { return pressure; }
			set { SetValue(ref pressure, value); }
		}
		#endregion

		#region Methods
		public async void GetTemperature() 
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("http://api.openweathermap.org");
            var url = "/data/2.5/forecast/daily?id=6356055&cnt=5&units=metric&appid=50d4d8b59f8c1a0a41360976992f86f1";
            var response = await Client.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsStringAsync();
                forecast = JsonConvert.DeserializeObject<Forecast>(results);
                Temperature = Math.Round(forecast.list[0].temp.day);
                Description = forecast.list[0].weather[0].main;
                City = forecast.city.name.ToUpper();
                CountryCode = forecast.city.country;
                Humidity = forecast.list[0].humidity +"%";
                var windAux = 0.0;
                windAux = (forecast.list[0].speed * 60 * 60) / 1000;
                Wind = string.Format("{0:0.00}",windAux);
                Wind += " km/h";
                Clouds = forecast.list[0].clouds + "%";
                Pressure = forecast.list[0].pressure.ToString();
                Pressure = Pressure.Substring(0, 4) + " pHa";
                GetCountryName();
             }
        }

        void GetUserInfo()
        {
            if (DateTime.Now.Hour > 11)
            {
                currentTime = (DateTime.Now.Hour - 12) + ":" + DateTime.Now.Minute + " PM";
            }

            else
            {
                currentTime = DateTime.Now.Hour + ":" + DateTime.Now.Minute + " AM";
            }

            CurrentDate = DateTime.Now.Date.ToLongDateString();
        }

        async void GetCountryName()
        {
            //https://restcountries.eu/rest/v2/alpha/col
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://restcountries.eu");
            string url = "/rest/v2/alpha/"+CountryCode;
            var response = await Client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var results = await response.Content.ReadAsStringAsync();
                country = JsonConvert.DeserializeObject<Country>(results);
                CountryName = country.name.ToUpper();
            }
            else
            {
                //Display message error
            }
        }
        #endregion

		#region Constructor
		public HomeViewModel()
		{

            GetTemperature();
            /*   CHANGE HOUR EVERY MINUTE
             * 
             * 
             * 
             * 
             *
             */

            /*
             * 
             * IMPROVE DATE SYSTEM
             */

            GetUserInfo();
		}
        #endregion
	}
}
