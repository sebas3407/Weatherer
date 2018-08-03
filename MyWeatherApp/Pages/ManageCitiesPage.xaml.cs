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

			ToolbarItems.Add(new ToolbarItem("Use GPS","gps_active.png", async () =>
            {
            }));
        }
    }
}