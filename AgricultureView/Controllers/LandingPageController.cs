using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Controllers
{
       [AllowAnonymous]
    public class LandingPageController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public LandingPageController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }

        public async Task<IActionResult> Index()
        {
            var model = new LandingPageViewModel();
            var programResponse = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllProgram");
            if (programResponse.Status)
            {
                model.Programs = JsonConvert.DeserializeObject<List<AgricultureProgramViewModel>>(programResponse.Data.ToString());
            }
            var projectResponse = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllProject");
            if (projectResponse.Status)
            {
                model.Projects = JsonConvert.DeserializeObject<List<AgricultureProjectViewModel>>(projectResponse.Data.ToString());
            }
            var serviceResponse = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllService");
            if (serviceResponse.Status)
            {
              model.Services = JsonConvert.DeserializeObject<List<AgricultureServiceViewModel>>(serviceResponse.Data.ToString());
            }
            var farmerRsponse = await _globalVeriable.GetMethod("Admin/Farmer/GetAllFarmer");
            if (farmerRsponse.Status)
            {
                model.Farmers = JsonConvert.DeserializeObject<List<FarmerViewModel>>(farmerRsponse.Data.ToString());
            }
            //var formResponse = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllApplicatoionForm");
            //if (formResponse.Status)
            //{
            //    model.AdditionalServices = JsonConvert.DeserializeObject<List<AgricultureApplicatoionFormViewModel>>(formResponse.Data.ToString());
            //}
            return View(model);
        }
    }
}
