using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SuchanaViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public SuchanaViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        public async Task<IActionResult> Suchana()
        {
            var response = await _globalVeriable.GetMethod("Admin/Suchana/GetAllSuchana");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<SuchanaViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<SuchanaViewModel>());
        }

        public async Task<IActionResult> SuchanaDetail(int id )
        {
            var response = await _globalVeriable.GetMethod("Admin/Suchana/GetSuchanaById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<SuchanaViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new SuchanaViewModel());
        }
        public async Task<IActionResult> CreateSuchana(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Suchana/GetSuchanaById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<SuchanaViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new SuchanaViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateSuchana(SuchanaViewModel model)
        {
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(model.Id.ToString()), "Id");
                formData.Add(new StringContent(model.FiscalYearId.ToString()), "FiscalYearId");
                formData.Add(new StringContent(model.Description), "Description");
                formData.Add(new StringContent(model.Title), "Title");


                if (model.FilePhoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.FilePhoto.OpenReadStream());
                    formData.Add(photoContent, "FilePhoto", model.FilePhoto.FileName);
                }

                var response = await _globalVeriable.PostFileMethod("Admin/Suchana/CreateSuchana", formData);
                if (response.Status)
                {
                    return RedirectToAction("Suchana");
                }
            }
            return View(model);

        }
    }
}
