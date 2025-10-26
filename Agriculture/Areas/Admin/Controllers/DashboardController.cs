using Agriculture.Areas.Admin.Interface;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboard _dashboard;

        public DashboardController(IDashboard dashboard)
        {
            _dashboard = dashboard;
        }
        [HttpGet("GetDashboardData")]
        public async Task<IActionResult> GetDashboardData()
        {
            var data = await _dashboard.GetDashboardData();
            return Ok(new ApiResponse() { Status = data != null, Data = data, Message = data != null ? "Dashboard Data Generated" : "Not Generated Try Again " });
        }
        [HttpGet("GetHomePageData")]
        public async Task<IActionResult> GetHomePageData()
        {
            var data = await _dashboard.GetHomePageData();
            return Ok(new ApiResponse() { Status = data != null, Data = data, Message = data != null ? "Dashboard Data Generated" : "Not Generated Try Again " });
        }
    }
}
