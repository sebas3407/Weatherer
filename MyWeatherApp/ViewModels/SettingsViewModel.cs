using System;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using MyWeatherApp.Popups;

namespace MyWeatherApp.ViewModels
{
	public class SettingsViewModel : BaseViewModel
    {
		public RelayCommand NewCityPopupCommand { get; set; }
		async void NewCityPopup()
        {
			await Application.Current.MainPage.Navigation.PushPopupAsync(new AddCityPopup());
        }

        public SettingsViewModel()
        {
    	    NewCityPopupCommand = new RelayCommand(NewCityPopup);
        }
    }
}
