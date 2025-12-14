using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AgriCalendarViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public AgriCalendarViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        #region AgriCalendarType
        public async Task<IActionResult> AgriCalendarType()
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendarType");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgriCalendarTypeViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgriCalendarTypeViewModel>());
        }
        public async Task<IActionResult> AgriCalendarTypeCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAgriCalendarTypeById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgriCalendarTypeViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgriCalendarTypeViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AgriCalendarTypeCreate(AgriCalendarTypeViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/AgriCalendar/CreateAgriCalendarType", model);
            if (response.Status)
            {
                return RedirectToAction("AgriCalendarType");
            }
            return View(model);
        }
        #endregion
        #region AgriCalendarCategory
        public async Task<IActionResult> AgriCalendarCategory()
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendarCategory");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgriCalendarCategoryViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgriCalendarCategoryViewModel>());
        }
        public async Task<IActionResult> AgriCalendarCategoryCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAgriCalendarCategoryById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgriCalendarCategoryViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgriCalendarCategoryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AgriCalendarCategoryCreate(AgriCalendarCategoryViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/AgriCalendar/CreateAgriCalendarCategory", model);
            if (response.Status)
            {
                return RedirectToAction("AgriCalendarCategory");
            }
            return View(model);
        }
        #endregion
        #region AgriCalendarProduct
        public async Task<IActionResult> AgriCalendarProduct()
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendarProduct");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgriCalendarProductViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgriCalendarProductViewModel>());
        }
        public async Task<IActionResult> AgriCalendarProductCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAgriCalendarProductById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgriCalendarProductViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgriCalendarProductViewModel());
        }
        public async Task<IActionResult> AgriCalendarProductDetail(int id )
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAgriCalendarProductById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgriCalendarProductViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgriCalendarProductViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AgriCalendarProductCreate(AgriCalendarProductViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/AgriCalendar/CreateAgriCalendarProduct", model);
            if (response.Status)
            {
                return RedirectToAction("AgriCalendarProduct");
            }
            return View(model);
        }
        #endregion
        #region AgriCalendar
        public async Task<IActionResult> AgriCalendar()
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendar");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AgriCalendarViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AgriCalendarViewModel>());
        }
        public async Task<IActionResult> AgriCalendarCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAgriCalendarById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgriCalendarViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgriCalendarViewModel());
        }
        public async Task<IActionResult> AgriCalendarDetails(int id )
        {
            var response = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAgriCalendarById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AgriCalendarViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AgriCalendarViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> AgriCalendarCreate(AgriCalendarViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/AgriCalendar/CreateAgriCalendar", model);
            if (response.Status)
            {
                return RedirectToAction("AgriCalendar");
            }
            return View(model);
        }
        public IActionResult AgriCalendarDetail() => PartialView("_AgriCalendarDetail", new AgriCalendarDetailViewModel());

        #endregion
    }
}
