﻿using MyWeatherApp.ViewModels;
namespace MyWeatherApp.Infrastructure
{
	public class InstanceLocator
    {
        public MainViewModel Main
        {
            get;
            set;
        } 

        public InstanceLocator()
        {
            Main = new MainViewModel();
        }
    }
}
