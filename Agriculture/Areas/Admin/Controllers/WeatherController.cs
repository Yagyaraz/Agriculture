using Agriculture.Areas.Admin.Interface;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Azure.Core.HttpHeader;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly IWeather _Weather;
        public WeatherController(IWeather weather)
        {
            _Weather = weather;
        }

        [HttpGet("GetAllWeather/{id}")]
        public async Task<IActionResult> GetAllWeather(int id)
        {
            var data = await _Weather.GetAllWeather(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null? "Successfully Generated All List of Weather" : "Weather Not Generated Try Again", Data = data });
        }
    }
}
