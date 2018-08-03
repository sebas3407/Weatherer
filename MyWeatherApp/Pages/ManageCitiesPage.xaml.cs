using MyWeatherApp.Popups;
using MyWeatherApp.ViewModels;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace MyWeatherApp.Pages
{
    public partial class ManageCitiesPage : ContentPage
    {
        public ManageCitiesPage()
        {
            InitializeComponent();
			ToolbarItems.Add(new ToolbarItem("Settings", "settings.png", async () =>
            {
				MainViewModel.GetInstance().SettingsUnits = new SettingsUnitsViewModel();
				await Application.Current.MainPage.Navigation.PushPopupAsync(new SettingsUnitsPopup());
            }));
        }

		async void Handle_Toggled(object sender, ToggledEventArgs e)
		{
			MainViewModel.GetInstance().Home.UseGPS = true;
			await Application.Current.MainPage.Navigation.PopAsync();
		}
	}
}