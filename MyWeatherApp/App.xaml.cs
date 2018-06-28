using System;
using MyWeatherApp.Pages;
using MyWeatherApp.Resources;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyWeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

			NavigationPage navigationPage = new NavigationPage(new Pages.HomePage());
            navigationPage.BarBackgroundColor = Colors.MainColor;
            navigationPage.BarTextColor = Color.White;

            MainPage = navigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
