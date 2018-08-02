using System;
using System.ComponentModel;
using System.Globalization;
using System.Net.Http;
using Newtonsoft.Json;
using MyWeatherApp.Classes;

namespace MyWeatherApp.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region ViewModels      
		public HomeViewModel Home { get; set; }
		public SettingsViewModel Settings { get; set; }
		public AddCityViewModel AddCity { get; set; }
		public ManageCitiesViewModel ManageCity { get; set; }
		public SettingsUnitsViewModel SettingsUnits { get; set; }
        #endregion

		#region Singleton
		private static MainViewModel instance;

        public static MainViewModel GetInstance()
        {
            if (instance == null)
            {
				return new MainViewModel();
            }

            return instance;
        }
        #endregion

        public MainViewModel()
        {
			instance = this;
			this.Home = new HomeViewModel();
        }
    }
}