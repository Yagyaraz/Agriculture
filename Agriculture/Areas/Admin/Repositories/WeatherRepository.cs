using Agriculture.Areas.Admin.Interface;
using Agriculture.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Security.Claims;
using static Agriculture.Areas.Admin.Models.WeatherViewModel;

namespace Agriculture.Areas.Admin.Repositories
{
    public class WeatherRepository : IWeather
    {
        private readonly AgricultureDbContext _context;
        private readonly HttpClient _httpClient;
        private readonly ILogger<WeatherRepository> _logger;
        private readonly string _userId;

        public WeatherRepository(HttpClient httpClient, ILogger<WeatherRepository> logger, IHttpContextAccessor httpContextAccessor, AgricultureDbContext context)
        {
            _httpClient = httpClient;
            _logger = logger;
            _userId = httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
            _context = context;
        }

        public async Task<CustomResponseWeatherReport> GetAllWeather(int location)
        {
            try
            {
                var setupDistrict = await _context.Office.Select(x => x.District.DistrictName).FirstOrDefaultAsync();
                var distName = await _context.District.Where(x => x.DistrictId == location).Select(x => x.DistrictName).FirstOrDefaultAsync();
                var newLocation = location == 0 ? (setupDistrict != null ? setupDistrict : "Kathmandu") : distName;

                string apiKey = "804b5dd8d1f156f7bc8cdc17259d3f88";
                string url = $"https://api.openweathermap.org/data/2.5/weather?q={newLocation}&appid={apiKey}&units=metric";

                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var weatherData = JsonConvert.DeserializeObject<WeatherResponse>(jsonResponse);

                    return new CustomResponseWeatherReport
                    {
                        Name = weatherData.Name,
                        Temp = weatherData.Main.Temp,
                        FeelsLike = weatherData.Main.FeelsLike,
                        TempMin = weatherData.Main.TempMin,
                        TempMax = weatherData.Main.TempMax,
                        Humidity = weatherData.Main.Humidity,
                        Pressure = weatherData.Main.Pressure,
                        Visibility = weatherData.Visibility,
                        WindSpeed = weatherData.Wind.Speed,
                        WindDirection = weatherData.Wind.Deg,

                    };
                }
                else
                {
                    _logger.LogWarning($"Failed to fetch weather data for location: {newLocation}. Status Code: {response.StatusCode}, Reason: {response.ReasonPhrase}");
                    return null;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error fetching weather data for location: {location}. User Id: {_userId}, Date: {DateTime.Now}, Exception: {ex}");
                return null;
            }
        }
    }
}
