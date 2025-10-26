using static Agriculture.Areas.Admin.Models.WeatherViewModel;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IWeather
    {
        Task<CustomResponseWeatherReport> GetAllWeather(int location);
    }
}
