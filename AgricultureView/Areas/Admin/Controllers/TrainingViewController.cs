using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TrainingViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public TrainingViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        public async Task<IActionResult> Training()
        {
            var response = await _globalVeriable.GetMethod("Admin/Training/GetAllTraining");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<TrainingViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<TrainingViewModel>());
        }

        public async Task<IActionResult> TrainingDetail(int id )
        {
            var response = await _globalVeriable.GetMethod("Admin/Training/GetTrainingById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<TrainingViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new TrainingViewModel());
        }
        public async Task<IActionResult> CreateTraining(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Training/GetTrainingById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<TrainingViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new TrainingViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateTraining(TrainingViewModel model)
        {
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(model.Id.ToString()), "Id");
                formData.Add(new StringContent(model.FiscalYearId.ToString()), "FiscalYearId");
                formData.Add(new StringContent(model.Title), "Title");
                formData.Add(new StringContent(model.TrainerName), "TrainerName");
                formData.Add(new StringContent(model.TrainingPlace), "TrainingPlace");
                formData.Add(new StringContent(model.PremiumId.ToString()), "PremiumId");
                formData.Add(new StringContent(model.Amount.ToString()), "Amount");
                formData.Add(new StringContent(model.TrainingTypeId.ToString()), "TrainingTypeId");
                formData.Add(new StringContent(model.StartDate), "StartDate");
                formData.Add(new StringContent(model.StartDateEng.ToString()), "StartDateEng");
                formData.Add(new StringContent(model.EndDate), "EndDate");
                formData.Add(new StringContent(model.EndDateEng.ToString()), "EndDateEng");
                formData.Add(new StringContent(model.Organizer), "Organizer");
                formData.Add(new StringContent(model.Description), "Description");


                if (model.FilePoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.FilePoto.OpenReadStream());
                    formData.Add(photoContent, "FilePoto", model.FilePoto.FileName);
                }

                var response = await _globalVeriable.PostFileMethod("Admin/Training/CreateTraining", formData);
                if (response.Status)
                {
                    return RedirectToAction("Training");
                }
            }
            return View(model);

        }
    }
}
