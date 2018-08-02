using GalaSoft.MvvmLight.Command;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace MyWeatherApp.ViewModels
{
	public class SettingsUnitsViewModel : BaseViewModel
	{
		#region Properties
		private bool isCentigrades;
		public bool IsCentigrades
		{
			get { return isCentigrades; }
			set { SetValue(ref isCentigrades, value); }
		}

		private bool isFahrenheit;
		public bool IsFahrenheit
		{
			get { return isFahrenheit; }
			set { SetValue(ref isFahrenheit, value); }
		}

		private bool isKelvin;
		public bool IsKelvin
		{
			get { return isKelvin; }
			set { SetValue(ref isKelvin, value); }
		}
		#endregion

		#region Commands
		public RelayCommand ClosePopupCommand { get; set; }
        async void ClosePopup()
        {
            MainViewModel.GetInstance().AddCity = new AddCityViewModel();
			await Application.Current.MainPage.Navigation.PopPopupAsync();
        }
        #endregion

		#region Constructor
		public SettingsUnitsViewModel()
		{
			ClosePopupCommand = new RelayCommand(ClosePopup);
		}
        #endregion
	}
}