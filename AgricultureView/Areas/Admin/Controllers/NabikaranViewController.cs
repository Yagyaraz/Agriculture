using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NabikaranViewController : Controller
    {
        #region Nabikaran
        private readonly IGlobalVeriable _globalVeriable;
        public NabikaranViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        public async Task<IActionResult> NabikaranList()
        {
            var response = await _globalVeriable.GetMethod("Admin/Nabikaran/GetAllNabikaran");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<NabikaranViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<NabikaranViewModel>());
        }
       
        public async Task<IActionResult> NabikaranDetail(int id)
        {
            var response = await _globalVeriable.GetMethod("Admin/Nabikaran/GetNabikaranById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<NabikaranViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new NabikaranViewModel());
        }

        public async Task<IActionResult> CreateNabikaran(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Nabikaran/GetNabikaranById/" + id);
            if (response.Status)
            {
                var data = JsonConvert.DeserializeObject<NabikaranViewModel>(response.Data.ToString());

                // VERY IMPORTANT
                data.FirmId = id;

                return View(data);
            }

            return View(new NabikaranViewModel
            {
                FirmId = id
            });
        }
        [HttpPost]
        public async Task<IActionResult> CreateNabikaran(NabikaranViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Nabikaran/CreateNabikaran", model);
            if (response.Status)
            {
                return RedirectToAction("Index", "AgricultureFarmerGroupView", new { area = "Admin" });
            }
            return View(model);
        }
        #endregion
    }
}
