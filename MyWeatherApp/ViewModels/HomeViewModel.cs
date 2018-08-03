using System;
using System.Net.Http;
using Newtonsoft.Json;
using MyWeatherApp.Classes;
using System.Collections.Generic;
using MyWeatherApp.Services;
using Xamarin.Forms;

namespace MyWeatherApp.ViewModels
{
	public class HomeViewModel: BaseViewModel
	{
		#region Properties

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

		private double latitude;
		public double Latitude
        {
			get { return latitude; }
			set { SetValue(ref latitude, value); }
        }

		private double longitude;
		public double Longitude
        {
			get { return longitude; }
			set { SetValue(ref longitude, value); }
        }

		private string fontStyle;
        public string FontStyle
        {
			get { return fontStyle; }
			set { SetValue(ref fontStyle, value); }
        }

		private bool useGPS;
		public bool UseGPS
        {
			get { return useGPS; }
			set { SetValue(ref useGPS, value); }
        }

		private Forecast forecast;
        private Country country;
        private ApiService apiService = new ApiService();
		public List<Temperature> ListMaxTemperatures { get; set; }
		public List<Temperature> ListMinTemperatures { get; set; }
		public string apiKey = "50d4d8b59f8c1a0a41360976992f86f1";
        public string units = "metric";
		LocalizationService MyLocalization = new LocalizationService();
		InternetConnection internetConnection = new InternetConnection();
        #endregion

        #region Methods
        public async void GetTemperature()
        {
			await MyLocalization.GetCurrentLocation();
            Latitude = MyLocalization.latitude;
            Longitude = MyLocalization.longitude;

			if(!useGPS)
			{
				Latitude = 40.416775;
                Longitude = -3.703790;
			}

			var url = "/data/2.5/forecast/daily?lat="+Latitude+"&lon="+Longitude+"&cnt=5&units=" + units + "&appid=" + apiKey;
            forecast = await apiService.GetForecast(url);
            if (apiService.SuccessConnection)
            {
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
				GetGraphData();
             }

			if (Latitude == 0 && Longitude == 0)             {                 await Application.Current.MainPage.DisplayAlert("Error", "Can't access to GPS", "Accept");             }         }

		void GetGraphData()
		{
			DateTime currentDate = DateTime.Today.AddDays(-1);
			for (int i = 0; i < 5;i++)
			{
				currentDate = currentDate.AddDays(1);
				Temperature minTempAux = new Temperature(currentDate, Math.Round(forecast.list[i].temp.min),false);
				Temperature maxTempAux = new Temperature(currentDate, Math.Round(forecast.list[i].temp.max), false);
                
				ListMinTemperatures.Add(minTempAux);
                ListMaxTemperatures.Add(maxTempAux);
			}   
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
        }
        #endregion

		#region ConstructorGetUserInfo
		public HomeViewModel()
		{
			ListMinTemperatures = new List<Temperature>();
			ListMaxTemperatures = new List<Temperature>();
            GetTemperature();
			CurrentDate = DateTime.Now.Date.ToLongDateString();
			FontStyle = "None";
		}
        #endregion
	}
}