using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using MyWeatherApp.ViewModels;

namespace MyWeatherApp.Popups
{
	public partial class SettingsUnitsPopup : PopupPage
    {
        public SettingsUnitsPopup()
        {
            InitializeComponent();
        }

		void Handle_Toggled(object sender, ToggledEventArgs e)
		{
			var grades = sender as Switch;
			if(grades == CentigradesSwitch)
			{
				MainViewModel.GetInstance().SettingsUnits.IsFahrenheit = false;
				MainViewModel.GetInstance().SettingsUnits.IsKelvin = false;
			}
			else if(grades == FahrenheitSwitch)
			{
				MainViewModel.GetInstance().SettingsUnits.IsCentigrades = false;
				MainViewModel.GetInstance().SettingsUnits.IsKelvin = false;
			}
			else
			{
				MainViewModel.GetInstance().SettingsUnits.IsCentigrades = false;
				MainViewModel.GetInstance().SettingsUnits.IsFahrenheit = false;
			}
		}
    }
}