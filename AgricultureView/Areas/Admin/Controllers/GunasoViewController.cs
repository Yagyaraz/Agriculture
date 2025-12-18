using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GunasoViewController : Controller
    {
        #region Gunaso
        private readonly IGlobalVeriable _globalVeriable;
        public GunasoViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        public async Task<IActionResult> GunasoList()
        {
            var response = await _globalVeriable.GetMethod("Admin/Gunaso/GetAllGunaso");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<GunasoViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<GunasoViewModel>());
        }
        public async Task<IActionResult> CreateGunaso(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Gunaso/GetGunaosById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<GunasoViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new GunasoViewModel());
        }
        [AllowAnonymous]
        public async Task<IActionResult> GunasoDetail(int id)
        {
            var response = await _globalVeriable.GetMethod("Admin/Gunaso/GetGunaosById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<GunasoViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new GunasoViewModel());
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> CreateGunaso(LandingPageViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Gunaso/CreateGunaos", model.Gunaso);
            if (response.Status)
            {
                return RedirectToAction("Index", "LandingPage", new { area = "" });
            }
            return View(model);
        }
        #endregion
    }
}
