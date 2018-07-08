using GalaSoft.MvvmLight.Command;
using MyWeatherApp.Popups;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace MyWeatherApp.ViewModels
{
	public class ManageCitiesViewModel
    {
		public RelayCommand NewCityPopupCommand { get; set; }
        async void NewCityPopup()
        {
            MainViewModel.GetInstance().AddCity = new AddCityViewModel();
            await Application.Current.MainPage.Navigation.PushPopupAsync(new AddCityPopup());
        }

		public ManageCitiesViewModel()
        {
            NewCityPopupCommand = new RelayCommand(NewCityPopup);
        }
    }
}
