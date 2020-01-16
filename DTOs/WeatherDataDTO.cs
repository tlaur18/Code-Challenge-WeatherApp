using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWeatherApp.DTOs
{
    public class WeatherDataDTO
    {
        public Report report { get; set; }
    }

    public class Report
    {
        public Conditions conditions { get; set; }
        public Forecast forecast { get; set; }
    }

    public class Conditions
    {
        public string dateIssued { get; set; }
        public double tempC { get; set; }
        public double pressureHg { get; set; }
        public Wind wind { get; set; }
        public Visibility visibility { get; set; }
        public Period period { get; set; }
    }

    public class Forecast
    {
        public IList<Conditions> conditions { get; set; }
    }

    public class Period
    {
        public string dateStart { get; set; }
        public string dateEnd { get; set; }
    }

    public class Wind
    {
        public double speedKts { get; set; }
        public double gustSpeedKts { get; set; }
        public double direction { get; set; }
    }

    public class Visibility
    {
        public double distanceSm { get; set; }
    }
}
