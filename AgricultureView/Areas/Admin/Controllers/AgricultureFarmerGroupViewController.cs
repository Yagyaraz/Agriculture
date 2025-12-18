using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgricultureFarmerGroupViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public AgricultureFarmerGroupViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _globalVeriable.GetMethod("Admin/AgricultureFarmerGroup/GetAllAgricultureFarmerGroup");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgricultureFarmerGroupViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgricultureFarmerGroupViewModel>());
        }

        public async Task<IActionResult> Create(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgricultureFarmerGroup/GetAgricultureFarmerGroupById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgricultureFarmerGroupViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgricultureFarmerGroupViewModel());
        }
        public async Task<IActionResult> GetAgricultureFarmerGroupById(int id)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgricultureFarmerGroup/GetAgricultureFarmerGroupById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgricultureFarmerGroupViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgricultureFarmerGroupViewModel());
        }
        public async Task<IActionResult> PranamPatra(int id)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgricultureFarmerGroup/GetAgricultureFarmerGroupById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgricultureFarmerGroupViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgricultureFarmerGroupViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(AgricultureFarmerGroupViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/AgricultureFarmerGroup/CreateAgricultureFarmerGroup", model);
            if (response.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult OfficialPost() => PartialView("_OfficialPost", new OfficialsDetailViewModel());

    }
}
