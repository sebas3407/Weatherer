using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using MyWeatherApp.Classes;
using MyWeatherApp.Models;
using MyWeatherApp.Popups;
using MyWeatherApp.Services;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace MyWeatherApp.ViewModels
{
    public class ManageCitiesViewModel : BaseViewModel
	{
		#region Properties
		double latitude;
		double longitude;

		private bool useGPS;
		public bool UseGPS
        {
			get { return useGPS; }
			set { SetValue(ref useGPS, value); }
        }
	
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

        private ApiService apiService = new ApiService();
        LocalizationService MyLocalization = new LocalizationService();
        ObservableCollection<LocalCity> CitiesList = new ObservableCollection<LocalCity>();
        #endregion

        #region Commands
        public RelayCommand AddCityCommand { get; set; }
        async void AddCity()
        {
            string url = "data/2.5/forecast/daily?q=" + City + "&cnt=5&units=metric&appid=50d4d8b59f8c1a0a41360976992f86f1";

            Forecast cityForecast;
            cityForecast = await apiService.GetForecast(url);

            if (cityForecast != null)
            {
                IsVisible = false;

                LocalCity NewCity = new LocalCity
                {
                    name = cityForecast.city.name,
                    countryName = cityForecast.city.country,
                    latitude = cityForecast.city.coord.lat,
                    longitude = cityForecast.city.coord.lon
                };

                if (!CitiesList.Any(
                    i => i.name == NewCity.name &&
                    i.countryName == NewCity.countryName))
                {
                    CitiesList.Add(NewCity);
                }
                await Application.Current.MainPage.Navigation.PopPopupAsync();
            }
            else
            {
                IsVisible = true;
            }
        }

		public RelayCommand NewCityPopupCommand { get; set; }
		async void NewCityPopup()
		{
			await Application.Current.MainPage.Navigation.PushPopupAsync(new AddCityPopup());
		}

		public async void GetCurrentLocation()
		{
			await MyLocalization.GetCurrentLocation();
			latitude = MyLocalization.latitude;
			longitude = MyLocalization.longitude;
		}
		#endregion

		#region Constructor
		public ManageCitiesViewModel()
		{
			NewCityPopupCommand = new RelayCommand(NewCityPopup);
            AddCityCommand = new RelayCommand(AddCity);
		}
		#endregion
	}
}