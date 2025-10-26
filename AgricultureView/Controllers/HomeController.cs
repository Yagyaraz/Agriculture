using AgricultureView.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace AgricultureView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IGlobalVeriable _global;

        public HomeController(ILogger<HomeController> logger, IGlobalVeriable global)
        {
            _global = global;
            _logger = logger;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _global.GetMethod("Admin/Dashboard/GetDashboardData");
            if (response.Status)
            {
                var data = JsonConvert.DeserializeObject<DashboardMVCViewModel>(response.Data.ToString());
                return View(data);
            }
            return View(new DashboardMVCViewModel());
        }
        public async Task<JsonResult> GetHomePageData()
        {
            var response = await _global.GetMethod("Admin/Dashboard/GetHomePageData");
            if (response.Status)
            {
                var data = JsonConvert.DeserializeObject<DashboardBargraphViewModel>(response.Data.ToString());
                return Json(data);
            }
            return Json(new DashboardBargraphViewModel());
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult UserView()
        {
            return View();
        }
    }
}
