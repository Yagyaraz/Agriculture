using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class ApplicationFormViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public ApplicationFormViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        public async Task<IActionResult> ApplicationForm()
        {
            var response = await _globalVeriable.GetMethod("Admin/ApplicationForm/GetAllApplicationForm");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<ApplicationFormViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<ApplicationFormViewModel>());
        }

        public async Task<IActionResult> ApplicationFormDetail(int id )
        {
            var response = await _globalVeriable.GetMethod("Admin/ApplicationForm/GetApplicationFormById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<ApplicationFormViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new ApplicationFormViewModel());
        }
        public async Task<IActionResult> CreateApplicationForm(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/ApplicationForm/GetApplicationFormById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<ApplicationFormViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new ApplicationFormViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateApplicationForm(ApplicationFormViewModel model)
        {
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(model.Id.ToString()), "Id");
                formData.Add(new StringContent(model.FullName ?? ""), "FullName");
                formData.Add(new StringContent(model.Email ?? ""), "Email");
                formData.Add(new StringContent(model.Phone ?? ""), "Phone");
                formData.Add(new StringContent(model.Program ?? ""), "Program");
                formData.Add(new StringContent(model.Batch ?? ""), "Batch");

                // Optional fields
                formData.Add(new StringContent(model.Dob ?? ""), "Dob");
                formData.Add(new StringContent(model.Address ?? ""), "Address");
                formData.Add(new StringContent(model.Qualification ?? ""), "Qualification");
                formData.Add(new StringContent(model.Institution ?? ""), "Institution");
                formData.Add(new StringContent(model.Experience ?? ""), "Experience");
                formData.Add(new StringContent(model.Source ?? ""), "Source");
                formData.Add(new StringContent(model.Message ?? ""), "Message");


                if (model.Resume != null)
                {
                    StreamContent photoContent = new StreamContent(model.Resume.OpenReadStream());
                    formData.Add(photoContent, "Resume", model.Resume.FileName);
                }

                var response = await _globalVeriable.PostFileMethod("Admin/ApplicationForm/CreateApplicationForm", formData);
                if (response.Status)
                {
                    return RedirectToAction("Index", "LandingPage", new { area = "" });
                }
            }
            return View(model);

        }
    }
}
