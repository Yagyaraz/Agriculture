using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgriculturePlanViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public AgriculturePlanViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        #region Program
        public async Task<IActionResult> Program()
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllProgram");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgricultureProgramViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgricultureProgramViewModel>());
        }

        public async Task<IActionResult> CreateProgram(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetProgramById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgricultureProgramViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgricultureProgramViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateProgram(AgricultureProgramViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/AgriculturePlan/CreateProgram", model);
            if (response.Status)
            {
                return RedirectToAction("Program");
            }
            return View(model);
        }
        #endregion
        #region Project
        public async Task<IActionResult> Project()
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllProject");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgricultureProjectViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgricultureProjectViewModel>());
        }

        public async Task<IActionResult> CreateProject(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetProjectById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgricultureProjectViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgricultureProjectViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateProject(AgricultureProjectViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/AgriculturePlan/CreateProject", model);
            if (response.Status)
            {
                return RedirectToAction("Project");
            }
            return View(model);
        }
        #endregion
        #region Service
        public async Task<IActionResult> Service()
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllService");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgricultureServiceViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgricultureServiceViewModel>());
        }

        public async Task<IActionResult> CreateService(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetServiceById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgricultureServiceViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgricultureServiceViewModel());
        }
        public async Task<IActionResult> ServiceDetails(int id)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetServiceById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgricultureServiceViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgricultureServiceViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateService(AgricultureServiceViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/AgriculturePlan/CreateService", model);
            if (response.Status)
            {
                return RedirectToAction("Service");
            }
            return View(model);
        }
        public IActionResult AddService() => PartialView("_AddService", new AgricultureServiceAdditionalViewModel());

        #endregion
        #region ApplicatoionForm
        public async Task<IActionResult> ApplicatoionForm()
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllApplicatoionForm");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgricultureApplicatoionFormViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgricultureApplicatoionFormViewModel>());
        }

        public async Task<IActionResult> CreateApplicatoionForm(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetApplicatoionFormById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgricultureApplicatoionFormViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgricultureApplicatoionFormViewModel());
        }
        //[HttpPost]
        //public async Task<IActionResult> CreateApplicatoionForm(AgricultureApplicatoionFormViewModel model)
        //{
        //    using (var formData = new MultipartFormDataContent())
        //    {
        //        formData.Add(new StringContent(model.Id.ToString()), "Id");
        //        formData.Add(new StringContent(model.FiscalYearId.ToString()), "FiscalYearId");
        //        formData.Add(new StringContent(model.ProgramId.ToString()), "ProgramId");
        //        formData.Add(new StringContent(model.ProjectId.ToString()), "ProjectId");
        //        formData.Add(new StringContent(model.ServiceId.ToString()), "ServiceId");
        //        formData.Add(new StringContent(model.FarmerTypeId.ToString()), "FarmerTypeId");
        //        formData.Add(new StringContent(model.FarmerId.ToString()), "FarmerId");
        //        formData.Add(new StringContent(model.AgriGroupId.ToString()), "AgriGroupId");
        //        formData.Add(new StringContent(model.ContactName ?? ""), "ContactName");
        //        formData.Add(new StringContent(model.Remarks ?? ""), "Remarks");

        //        if (model.CitizenPhoto != null)
        //        {
        //            formData.Add(new StreamContent(model.CitizenPhoto.OpenReadStream()), "CitizenPhoto", model.CitizenPhoto.FileName);
        //        }
        //        if (model.LandOwnershipPhoto != null)
        //        {
        //            formData.Add(new StreamContent(model.LandOwnershipPhoto.OpenReadStream()), "LandOwnershipPhoto", model.LandOwnershipPhoto.FileName);
        //        }
        //        if (model.PlanDetailPhoto != null)
        //        {
        //            formData.Add(new StreamContent(model.PlanDetailPhoto.OpenReadStream()), "PlanDetailPhoto", model.PlanDetailPhoto.FileName);
        //        }

        //        var response = await _globalVeriable.PostMethod("Admin/AgriculturePlan/CreateApplicatoionForm", formData);
        //        if (response.Status)
        //        {
        //            return RedirectToAction("ApplicatoionForm");
        //        }
        //    }
        //    return View(model);
        //}
        [HttpPost]
        public async Task<IActionResult> CreateApplicatoionForm(AgricultureApplicatoionFormViewModel model)
        {
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(model.Id.ToString()), "Id");
                formData.Add(new StringContent(model.FiscalYearId.ToString()), "FiscalYearId");
                formData.Add(new StringContent(model.ProgramId.ToString()), "ProgramId");
                formData.Add(new StringContent(model.ProjectId.ToString()), "ProjectId");
                formData.Add(new StringContent(model.ServiceId.ToString()), "ServiceId");
                formData.Add(new StringContent(model.FarmerTypeId.ToString()), "FarmerTypeId");
                formData.Add(new StringContent(model.FarmerId.ToString()), "FarmerId");
                formData.Add(new StringContent(model.AgriGroupId.ToString()), "AgriGroupId");
                formData.Add(new StringContent(model.ContactName ?? ""), "ContactName");
                

                formData.Add(new StringContent(model.Remarks ?? ""), "Remarks");
                //formData.Add(new StringContent(model.CitizenPhotoPath ?? ""), "CitizenPhotoPath");
                //formData.Add(new StringContent(model.LandOwnershipPhotoPath ?? ""), "LandOwnershipPhotoPath");
                //formData.Add(new StringContent(model.PlanDetailPhotoPath ?? ""), "PlanDetailPhotoPath");

                if (model.CitizenPhoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.CitizenPhoto.OpenReadStream());
                    formData.Add(photoContent, "CitizenPhoto", model.CitizenPhoto.FileName);
                }
                if (model.LandOwnershipPhoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.LandOwnershipPhoto.OpenReadStream());
                    formData.Add(photoContent, "LandOwnershipPhoto", model.LandOwnershipPhoto.FileName);
                }
                if (model.PlanDetailPhoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.PlanDetailPhoto.OpenReadStream());
                    formData.Add(photoContent, "PlanDetailPhoto", model.PlanDetailPhoto.FileName);
                }
                if (model.PanjikaranPhoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.PanjikaranPhoto.OpenReadStream());
                    formData.Add(photoContent, "PanjikaranPhoto", model.PanjikaranPhoto.FileName);
                }
                if (model.SthailekhaPhoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.SthailekhaPhoto.OpenReadStream());
                    formData.Add(photoContent, "SthailekhaPhoto", model.SthailekhaPhoto.FileName);
                }
                if (model.TaxPhoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.TaxPhoto.OpenReadStream());
                    formData.Add(photoContent, "TaxPhoto", model.TaxPhoto.FileName);
                }
                if (model.MinutePhoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.MinutePhoto.OpenReadStream());
                    formData.Add(photoContent, "MinutePhoto", model.MinutePhoto.FileName);
                }
                if (model.SelfdecisionPhoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.SelfdecisionPhoto.OpenReadStream());
                    formData.Add(photoContent, "SelfdecisionPhoto", model.SelfdecisionPhoto.FileName);
                }


                var response = await _globalVeriable.PostFileMethod("Admin/AgriculturePlan/CreateApplicatoionForm", formData);
                if (response.Status)
                {
                    return RedirectToAction("ApplicatoionForm");
                }
            }
            return View(model);

        }

        #endregion
    }
}
