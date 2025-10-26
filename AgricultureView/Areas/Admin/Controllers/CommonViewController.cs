using AgricultureView.Areas.Admin.Models;
using AgricultureView.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommonViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        private readonly HttpClient _httpClient;
        public CommonViewController(IGlobalVeriable globalVeriable, HttpClient httpClient)
        {
            _globalVeriable = globalVeriable;
            _httpClient = httpClient;
        }
        #region FiscalYear
        public async Task<IActionResult> Index()
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetAllFiscalYear");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<FiscalYearViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<FiscalYearViewModel>());
        }
        public async Task<IActionResult> Create(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetFiscalYearById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<FiscalYearViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new FiscalYearViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> Create(FiscalYearViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Common/CreateFiscalYear", model);
            if (response.Status)
            {
                return RedirectToAction("Index");
            }
            return View(model);
        }
        #endregion
        #region Office
        public async Task<IActionResult> Office()
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetAllOffice");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<OfficeMVCViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<OfficeMVCViewModel>());
        }
        public async Task<IActionResult> OfficeCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetOfficeById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<OfficeMVCViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new OfficeMVCViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> OfficeCreate(OfficeMVCViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Common/CreateOffice", model);
            if (response.Status)
            {
                return RedirectToAction("Office");
            }
            return View(model);
        }
        #endregion
        #region EducationLevel
        public async Task<IActionResult> EducationLevel()
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetAllEducationLevel");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<CommonViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<CommonViewModel>());
        }
        public async Task<IActionResult> EducationLevelCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetEducationLevelById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<CommonViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new CommonViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> EducationLevelCreate(CommonViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Common/CreateEducationLevel", model);
            if (response.Status)
            {
                return RedirectToAction("EducationLevel");
            }
            return View(model);
        }
        #endregion
        #region FarmerGroup
        public async Task<IActionResult> FarmerGroup()
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetAllFarmerGroup");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<CommonViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<CommonViewModel>());
        }
        public async Task<IActionResult> FarmerGroupCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetFarmerGroupById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<CommonViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new CommonViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> FarmerGroupCreate(CommonViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Common/CreateFarmerGroup", model);
            if (response.Status)
            {
                return RedirectToAction("FarmerGroup");
            }
            return View(model);
        }
        #endregion
        #region WardSetup
        public async Task<IActionResult> WardSetup()
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetAllWardSetup");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<CommonViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<CommonViewModel>());
        }
        public async Task<IActionResult> WardSetupCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetWardSetupById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<CommonViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new CommonViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> WardSetupCreate(CommonViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Common/CreateWardSetup", model);
            if (response.Status)
            {
                return RedirectToAction("WardSetup");
            }
            return View(model);
        }
        #endregion
        #region FarmerCategory
        public async Task<IActionResult> FarmerCategory()
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetAllFarmerCategory");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<CommonViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<CommonViewModel>());
        }
        public async Task<IActionResult> FarmerCategoryCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetFarmerCategoryById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<CommonViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new CommonViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> FarmerCategoryCreate(CommonViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Common/CreateFarmerCategory", model);
            if (response.Status)
            {
                return RedirectToAction("FarmerCategory");
            }
            return View(model);
        }
        #endregion
        #region AnimalSetup
        public async Task<IActionResult> AnimalSetup()
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetAllAnimalSetup");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AnimalSetupViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AnimalSetupViewModel>());
        }
        public async Task<JsonResult> AnimalSetupCreate(int id, bool isChecked)
        {
            try
            {
                var data = new BooleianViewModel()
                {
                    Id = id,
                    IsSelect = isChecked,
                };
                var response = await _globalVeriable.PostMethod("Admin/Common/GetAnimalSetupById", data);
                if (response.Status)
                {
                    var dataa = JsonConvert.DeserializeObject<AnimalSetupViewModel>(response.Data.ToString());
                    return Json(dataa);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }
            return Json(new AnimalSetupViewModel());
        }
        #endregion

        #region Weather

        public async Task<IActionResult> Weather(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Weather/GetAllWeather/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<CustomResponseWeatherReport>(response.Data.ToString());
                return View(dataa);
            }
            return View(new CustomResponseWeatherReport());
        }

        public async Task<IActionResult> WeatherAfterAjax(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Weather/GetAllWeather/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<CustomResponseWeatherReport>(response.Data.ToString());
                return Json(dataa);
            }
            return Json(new CustomResponseWeatherReport());
        }

        #endregion

        #region Userlist
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Common/RegisterUser", model);
            if (response.Status)
            {
                return RedirectToAction("UserList");
            }
            return View(model);
        }
        public async Task<IActionResult> UserList()
        {
            var response = await _globalVeriable.GetMethod("Admin/Common/GetAllUserList");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<RegisterViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<RegisterViewModel>());
        }
        #endregion
    }
}
