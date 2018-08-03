using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using MyWeatherApp.Classes;
using MyWeatherApp.Models;
using MyWeatherApp.Services;

namespace MyWeatherApp.ViewModels
{
	public class AddCityViewModel : BaseViewModel
	{
		#region Properties
		private ApiService apiService = new ApiService();

		private string city;
		public string City
		{
			get { return city; }
			set { SetValue(ref city, value); }
		}

		private bool isVisible;
		public bool IsVisible
		{
			get { return isVisible; }
			set { SetValue(ref isVisible, value); }
		}
        
		List<LocalCity> CitiesList = new List<LocalCity>();
		#endregion

		#region Comands
		public RelayCommand AddCityCommand { get; set; }
		async void AddCity()
		{
			string url = "data/2.5/forecast/daily?q=" + City + "&cnt=5&units=metric&appid=50d4d8b59f8c1a0a41360976992f86f1";

			Forecast cityForecast;
			cityForecast = await apiService.GetForecast(url);

			if (cityForecast != null)
			{
				IsVisible = false;

				LocalCity NewCity = new LocalCity { 
					name = cityForecast.city.name, 
					latitude = cityForecast.city.coord.lat, 
					longitude = cityForecast.city.coord.lon };

				if(!CitiesList.Contains(NewCity))
				{
					CitiesList.Add(NewCity);
				}
			}
			else
			{
				IsVisible = true;
			}
		}
		#endregion

		#region Constructor
		public AddCityViewModel()
		{
			AddCityCommand = new RelayCommand(AddCity);
		}
		#endregion
	}
}