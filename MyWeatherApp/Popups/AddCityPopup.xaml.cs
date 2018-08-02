using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;

namespace MyWeatherApp.Popups
{
	public partial class AddCityPopup : PopupPage
    {
		public AddCityPopup()
        {
            InitializeComponent();
        }

        async void GoBack()
        {
            await Navigation.PopPopupAsync();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }

        // ### Overrided methods which can prevent closing a popup page ###

        // Invoked when a hardware back button is pressed
        protected override bool OnBackButtonPressed()
        {
            // Return true if you don't want to close this popup page when a back button is pressed
            return base.OnBackButtonPressed();
        }

        // Invoked when background is clicked
        protected override bool OnBackgroundClicked()
        {
            // Return false if you don't want to close this popup page when a background of the popup page is clicked
            return base.OnBackgroundClicked();
        }
    }
}
