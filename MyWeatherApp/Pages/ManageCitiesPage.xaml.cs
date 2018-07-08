﻿using MyWeatherApp.ViewModels;
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
                MainViewModel.GetInstance().Settings = new SettingsViewModel();
                await Navigation.PushAsync(new SettingsPage(), true);
            }));
        }
    }
}
