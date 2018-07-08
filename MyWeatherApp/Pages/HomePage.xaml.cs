using System;
using System.Collections.Generic;
using MyWeatherApp.ViewModels;
using Xamarin.Forms;

namespace MyWeatherApp.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
			ToolbarItems.Add(new ToolbarItem("Cities", "cities.png", async () =>
            {
                MainViewModel.GetInstance().Settings = new SettingsViewModel();
                await Navigation.PushAsync(new SettingsPage(), true);
            }));
        }
    }
}
