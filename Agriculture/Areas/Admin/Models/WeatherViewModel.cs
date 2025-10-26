namespace Agriculture.Areas.Admin.Models
{
    public class WeatherViewModel
    {
        public class WeatherResponse
        {
            public Main Main { get; set; }
            public Wind Wind { get; set; }
            public string Name { get; set; }
            public string Visibility { get; set; }

        }

        public class Main
        {
            public double Temp { get; set; }
            public double TempMin { get; set; }
            public double TempMax { get; set; }
            public int Humidity { get; set; }
            public double FeelsLike { get; set; }
            public string Pressure { get; set; }
        }

        public class Wind
        {
            public double Speed { get; set; }
            public string Deg { get; set; }
        }

        public class CustomResponseWeatherReport
        {
            public string Name { get; set; }
            public double Temp { get; set; }
            public int Humidity { get; set; }
            public double FeelsLike { get; set; }
            public double TempMin { get; set; }
            public double TempMax { get; set; }
            public string Pressure { get; set; }
            public string Visibility { get; set; }
            public string WindDirection { get; set; }
            public double WindSpeed { get; set; }

        }
    }
}
