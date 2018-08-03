using GalaSoft.MvvmLight.Command;
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
		LocalizationService MyLocalization = new LocalizationService();

		#endregion

		#region Methods
		public RelayCommand NewCityPopupCommand { get; set; }
		async void NewCityPopup()
		{
			MainViewModel.GetInstance().AddCity = new AddCityViewModel();
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
		}
		#endregion
	}
}