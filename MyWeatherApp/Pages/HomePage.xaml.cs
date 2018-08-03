﻿using System;
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
				MainViewModel.GetInstance().ManageCity = new ManageCitiesViewModel();
				await Navigation.PushAsync(new ManageCitiesPage(), true);
            }));
        }

		protected override void OnAppearing()
		{
			MainViewModel.GetInstance().Home.GetTemperature();
			base.OnAppearing();
		}
	}
}
