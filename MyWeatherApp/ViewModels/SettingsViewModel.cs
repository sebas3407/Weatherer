using System;
namespace MyWeatherApp.ViewModels
{
	public class SettingsViewModel : BaseViewModel
    {
		private string test;
        public string Test
        {
            get { return test; }
			set { SetValue(ref test, value); } 

        }
        public SettingsViewModel()
        {
			Test = "Testing";
        }
    }
}
