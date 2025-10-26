using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class FarmerServiceViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public FarmerServiceViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        #region FarmerService
        public async Task<IActionResult> FarmerService()
        {
            var response = await _globalVeriable.GetMethod("Admin/FarmerService/GetAllFarmerService");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<FarmerServiceViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<FarmerServiceViewModel>());
        }

        public async Task<IActionResult> CreateFarmerService(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/FarmerService/GetFarmerServiceById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<FarmerServiceViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new FarmerServiceViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateFarmerService(FarmerServiceViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/FarmerService/CreateFarmerService", model);
            if (response.Status)
            {
                return RedirectToAction("FarmerService");
            }
            return View(model);
        }
        #endregion

        #region FarmerServiceCard
        public async Task<IActionResult> FarmerServiceCard()
        {
            var response = await _globalVeriable.GetMethod("Admin/FarmerService/GetAllFarmerServiceCard");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<FarmerServiceCardViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<FarmerServiceCardViewModel>());
        }

        public async Task<IActionResult> CreateFarmerServiceCard(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/FarmerService/GetFarmerServiceCardById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<FarmerServiceCardViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new FarmerServiceCardViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateFarmerServiceCard(FarmerServiceCardViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/FarmerService/CreateFarmerServiceCard", model);
            if (response.Status)
            {
                return RedirectToAction("FarmerServiceCard");
            }
            return View(model);
        }
        public IActionResult FarmerServiceCardDetail() => PartialView("_FarmerServiceCardDetail", new FarmerServiceCardDetailViewModel());

        #endregion
    }
}
