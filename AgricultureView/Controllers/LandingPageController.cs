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
            model.Programs =
                programResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<AgricultureProgramViewModel>>(
                        programResponse.Data?.ToString() ?? "[]")
                    : new List<AgricultureProgramViewModel>();

            var projectResponse = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllProject");
            model.Projects =
                projectResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<AgricultureProjectViewModel>>(
                        projectResponse.Data?.ToString() ?? "[]")
                    : new List<AgricultureProjectViewModel>();

            var serviceResponse = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllService");
            model.Services =
                serviceResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<AgricultureServiceViewModel>>(
                        serviceResponse.Data?.ToString() ?? "[]")
                    : new List<AgricultureServiceViewModel>();

            var farmerResponse = await _globalVeriable.GetMethod("Admin/Farmer/GetAllFarmer");
            model.Farmers =
                farmerResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<FarmerViewModel>>(
                        farmerResponse.Data?.ToString() ?? "[]")
                    : new List<FarmerViewModel>();

            var agriCalendarTypeResponse = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendarType");
            model.AgriCalendarTypes =
                agriCalendarTypeResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<AgriCalendarTypeViewModel>>(
                        agriCalendarTypeResponse.Data?.ToString() ?? "[]")
                    : new List<AgriCalendarTypeViewModel>();

            var agriCalendarCategoryResponse = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendarCategory");
            model.AgriCalendarCategories =
                agriCalendarCategoryResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<AgriCalendarCategoryViewModel>>(
                        agriCalendarCategoryResponse.Data?.ToString() ?? "[]")
                    : new List<AgriCalendarCategoryViewModel>();

            var agriCalendarProductResponse = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendarProduct");
            model.AgriCalendarProducts =
                agriCalendarProductResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<AgriCalendarProductViewModel>>(
                        agriCalendarProductResponse.Data?.ToString() ?? "[]")
                    : new List<AgriCalendarProductViewModel>();

            var agriCalendarResponse = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendar");
            model.AgriCalendars =
                agriCalendarResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<AgriCalendarViewModel>>(
                        agriCalendarResponse.Data?.ToString() ?? "[]")
                    : new List<AgriCalendarViewModel>();

            var farmerServiceResponse = await _globalVeriable.GetMethod("Admin/FarmerService/GetAllFarmerService");
            model.FarmerServices =
                farmerServiceResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<FarmerServiceViewModel>>(
                        farmerServiceResponse.Data?.ToString() ?? "[]")
                    : new List<FarmerServiceViewModel>();

            var farmerServiceCardResponse = await _globalVeriable.GetMethod("Admin/FarmerService/GetAllFarmerServiceCard");
            model.FarmerServiceCards =
                farmerServiceCardResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<FarmerServiceCardViewModel>>(
                        farmerServiceCardResponse.Data?.ToString() ?? "[]")
                    : new List<FarmerServiceCardViewModel>();

            var suchanaResponse = await _globalVeriable.GetMethod("Admin/Suchana/GetAllSuchana");
            model.Suchana =
                suchanaResponse?.Status == true
                    ? JsonConvert.DeserializeObject<List<SuchanaViewModel>>(
                        suchanaResponse.Data?.ToString() ?? "[]")
                    : new List<SuchanaViewModel>();

            return View(model);
        }
    }
}
