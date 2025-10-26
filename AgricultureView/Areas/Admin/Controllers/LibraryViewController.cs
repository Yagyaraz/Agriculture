using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Numerics;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LibraryViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public LibraryViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        public async Task<IActionResult> Library()
        {
            var response = await _globalVeriable.GetMethod("Admin/Library/GetAllLibrary");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<LibraryViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<LibraryViewModel>());
        }

        public async Task<IActionResult> CreateLibrary(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Library/GetLibraryById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<LibraryViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new LibraryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateLibrary(LibraryViewModel model)
        {
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(model.Id.ToString()), "Id");
                formData.Add(new StringContent(model.TypeId.ToString()), "TypeId");
                formData.Add(new StringContent(model.Title), "Title");
                formData.Add(new StringContent(model.Description), "Description");


                if (model.FilePoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.FilePoto.OpenReadStream());
                    formData.Add(photoContent, "FilePoto", model.FilePoto.FileName);
                }

                var response = await _globalVeriable.PostFileMethod("Admin/Library/CreateLibrary", formData);
                if (response.Status)
                {
                    return RedirectToAction("Library");
                }
            }
            return View(model);

        }
        public async Task<IActionResult> Detail(int id =0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Library/GetLibraryDetailById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<LibraryDetailViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new LibraryDetailViewModel());
        }
    }
}
