using AgricultureView.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Controllers
{
    public class AjaxMVCController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public AjaxMVCController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        public async Task<JsonResult> GetDistrictByStateId(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetDistrictSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return Json(new List<CommonTexValViewModel>());
        }
        public async Task<JsonResult> GetPalikaByDistId(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetPalikaSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return Json(new List<CommonTexValViewModel>());
        }

        public async Task<JsonResult> GetProjectByProgramId(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetProjectSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return Json(new List<CommonTexValViewModel>());
        }
        public async Task<JsonResult> GetServiceByProjectId(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetServiceByProjectId/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return Json(new List<CommonTexValViewModel>());
        }
        public async Task<JsonResult> GetCatId(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetSubCategorySelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return Json(new List<CommonTexValViewModel>());
        }
        public async Task<JsonResult> GetAgriCalendarTypeId(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriCalendarCategorySelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return Json(new List<CommonTexValViewModel>());
        }
        public async Task<JsonResult> GetAgriCalendarCategoryId(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriCalendarProductSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return Json(new List<CommonTexValViewModel>());
        }
        public async Task<JsonResult> GetAgriAgriServiceId(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriServiceSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return Json(data);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return Json(new List<CommonTexValViewModel>());
        }
    }
}
