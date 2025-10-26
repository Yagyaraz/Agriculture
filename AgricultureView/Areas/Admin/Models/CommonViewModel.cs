namespace AgricultureView.Areas.Admin.Models
{
    public class CommonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class AnimalSetupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public bool IsSelect { get; set; }
    }
    public class BooleianViewModel
    {
        public int Id { get; set; }
        public bool IsSelect { get; set; }
    }
    public class CustomResponseWeatherReport
    {
        public string Name { get; set; }
        public double Temp { get; set; }
        public int Humidity { get; set; }
        public string WindDirection { get; set; }
        public double WindSpeed { get; set; }

        public double TempMin { get; set; }
        public double TempMax { get; set; }

        public string Pressure { get; set; }
        public string Visibility { get; set; }
        public double FeelsLike { get; set; }

    }
}
