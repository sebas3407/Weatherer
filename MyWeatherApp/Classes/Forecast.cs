﻿using System;
using System.Collections.Generic;

namespace MyWeatherApp.Classes
{
    public class Forecast
    {
        public City city { get; set; }
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<List> list { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public Coord coord { get; set; }
        public string country { get; set; }
        public int population { get; set; }
    }

    public class Temp
    {
        public double day { get; set; }
        public double min { get; set; }
        public double max { get; set; }
        public double night { get; set; }
        public double eve { get; set; }
        public double morn { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class List
    {
        public int dt { get; set; }
        public Temp temp { get; set; }
        public double pressure { get; set; }
        public int humidity { get; set; }
        public List<Weather> weather { get; set; }
        public double speed { get; set; }
        public int deg { get; set; }
        public int clouds { get; set; }
        public double rain { get; set; }
    }

	public class Country
    {
        public string name { get; set; }
        public string alpha2Code { get; set; }
        public string alpha3Code { get; set; }
        public string nativeName { get; set; }
        public string numericCode { get; set; }
    }

	public class Temperature
    {
        public DateTime Day { get; set; }
        public double Temp { get; set; }
        public bool IsLastValue { get; set; }

		public Temperature(DateTime day, double temp, bool isLastValue)
		{
			Day = day;
			Temp = temp;
			IsLastValue = isLastValue;
		}
    }

    public class LocalForecast
    {
        public string Day { get; set; }
        public string Icon { get; set; }
        public string Max { get; set; }
        public string Min { get; set; }
    }
}