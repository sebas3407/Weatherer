using System;
using GalaSoft.MvvmLight.Command;
using MyWeatherApp.Popups;
using Plugin.Geolocator;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace MyWeatherApp.ViewModels
{
	public class ManageCitiesViewModel : BaseViewModel
	{
		#region Properties
		double latitude;
		double longitude;
		#endregion

		#region Methods
		public RelayCommand NewCityPopupCommand { get; set; }
		async void NewCityPopup()
		{
			MainViewModel.GetInstance().AddCity = new AddCityViewModel();
			GetCurrentLocation();
			await Application.Current.MainPage.Navigation.PushPopupAsync(new AddCityPopup());
		}

		public async void GetCurrentLocation()
		{
			var locator = CrossGeolocator.Current;
			var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

			latitude = position.Latitude;
			longitude = position.Longitude;
		}
		#endregion

		#region Constructor
		public ManageCitiesViewModel()
		{
			NewCityPopupCommand = new RelayCommand(NewCityPopup);
		}
		#endregion
	}
}
