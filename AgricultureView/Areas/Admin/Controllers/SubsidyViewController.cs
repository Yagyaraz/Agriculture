using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubsidyViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public SubsidyViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        #region Category
        public async Task<IActionResult> Category()
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllCategory");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<CategoryViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<CategoryViewModel>());
        }

        public async Task<IActionResult> CreateCategory(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetCategoryById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<CategoryViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new CategoryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CategoryViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Subsidy/CreateCategory", model);
            if (response.Status)
            {
                return RedirectToAction("Category");
            }
            return View(model);
        }

       
        #endregion
        #region SubCategory
        public async Task<IActionResult> SubCategory()
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllSubCategory");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<SubCategoryViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<SubCategoryViewModel>());
        }

        public async Task<IActionResult> CreateSubCategory(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetSubCategoryById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<SubCategoryViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new SubCategoryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubCategory(SubCategoryViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Subsidy/CreateSubCategory", model);
            if (response.Status)
            {
                return RedirectToAction("SubCategory");
            }
            return View(model);
        }
        #endregion
        #region Subsidy
        public async Task<IActionResult> SubsidyForUser()
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllSubsidyForUser");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<SubsidyViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<SubsidyViewModel>());
        }
        public async Task<IActionResult> Subsidy()
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllSubsidy");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<SubsidyViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<SubsidyViewModel>());
        }

        public async Task<IActionResult> CreateSubsidy(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetSubsidyById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<SubsidyViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new SubsidyViewModel());
        }
        public async Task<IActionResult> SubsidyDetails(int id )
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetSubsidyById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<SubsidyViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new SubsidyViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateSubsidy(SubsidyViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Subsidy/CreateSubsidy", model);
            if (response.Status)
            {
                return RedirectToAction("Subsidy");
            }
            return View(model);
        }
        public IActionResult SubsidyDetail() => PartialView("_SubsidyDetail", new SubsidyDetailViewModel());

        #region ForPOPUP

        public async Task<IActionResult> GetDataById(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetSubsidyByIdForPopUp/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<SubsidyPopupViewModel>(response.Data.ToString());
                return Json(dataa);
            }
            return Json(new SubsidyPopupViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> SaveRequestedSubsidy([FromBody] List<SaveRequestedSubsidyViewModel> data)
        {
            var response = await _globalVeriable.PostMethod("Admin/Subsidy/CareateSaveRequestedSubsidy", data);
            if (response.Status)
            {                
                return Json(response.Status);
            }
            return Json(new SaveRequestedSubsidyViewModel());
        }
        //[HttpPost]
        //public async Task<IActionResult> SaveRequestedSubsidy([FromBody] List<DartaModel> data)
        //{

        //}
        #endregion
        #endregion
        #region OtherSubsidy
        public async Task<IActionResult> OtherSubsidy()
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllOtherSubsidy");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<OtherSubsidyViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<OtherSubsidyViewModel>());
        }
        public async Task<IActionResult> OtherSubsidyDetails(int id)
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetOtherSubsidyById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<OtherSubsidyViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new OtherSubsidyViewModel());
        }
        public async Task<IActionResult> CreateOtherSubsidy(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/Subsidy/GetOtherSubsidyById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<OtherSubsidyViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new OtherSubsidyViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateOtherSubsidy(OtherSubsidyViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/Subsidy/CreateOtherSubsidy", model);
            if (response.Status)
            {
                return RedirectToAction("OtherSubsidy");
            }
            return View(model);
        }
        public IActionResult OtherSubsidyQns() => PartialView("_OtherSubsidyQns", new OtherSubsidyQnsViewModel());

        #endregion
    }
}
