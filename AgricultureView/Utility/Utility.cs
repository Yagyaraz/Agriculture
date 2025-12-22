using AgricultureView.Areas.Admin.Models;
using AgricultureView.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace AgricultureView.Utility
{
    public class Utility : IUtility
    {
        private readonly IGlobalVeriable _globalVeriable;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public Utility(IGlobalVeriable globalVeriable, IHttpContextAccessor httpContextAccessor)
        {
            _globalVeriable = globalVeriable;
            _httpContextAccessor = httpContextAccessor;
        }


        public async Task<LoginResponse?> GetSessionDetails()
        {
            var httpContext = _httpContextAccessor.HttpContext;
            if (httpContext == null)
                return null;

            var session = httpContext.Session.GetString("user");
            if (string.IsNullOrEmpty(session))
                return null;

            return JsonConvert.DeserializeObject<LoginResponse>(session);
        }

        public async Task<SelectList> GetFarmerSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetFarmerSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        } 
        public async Task<SelectList> GetWardNoSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetWardNoSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetStateSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetStateSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
       
        public async Task<SelectList> GetDistrictSelectListItems(int id = 0)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetDistrictSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetPalikaSelectListItems(int id = 0)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetPalikaSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetPalikaEngSelectListItems(int id = 0)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetPalikaEngSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetFiscalYearSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetFiscalYearSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }

        public async Task<SelectList> GetGenderSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetGenderSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }

        public async Task<SelectList> GetEducationSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetEducationSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }

        public async Task<SelectList> GetEducationLevelSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetEducationLevelSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }

        public async Task<SelectList> GetFarmerGroupSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetFarmerGroupSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }

        public async Task<SelectList> GetFarmerCategorySelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetFarmerCategorySelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetOnlyDistrictSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetOnlyDistrictSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetAvgmonthSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAvgmonthSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetAgriSectorSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriSectorSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetAgriServiceSelectListItems(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriServiceSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetRelationSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetRelationSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetWorkingAreaSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetWorkingAreaSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetOwnershipSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetOwnershipSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetLandTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetLandTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetIrrigationSourceSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetIrrigationSourceSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetCropsTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetCropsTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetFruitsTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetFruitsTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetSeedsTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetSeedsTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetMushroomTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetMushroomTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetSilkTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetSilkTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetBeeTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetBeeTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetProcustionMeasurementSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetProcustionMeasurementSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetProcustionUseSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetProcustionUseSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetKrishiFarmTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetKrishiFarmTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetPostSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetPostSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetAgriGroupTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriGroupTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetProgramSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetProgramSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetMeasuringUnitSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetMeasuringUnitSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetCategorySelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetCategorySelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetSubCategorySelectListItems(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetSubCategorySelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetProjectSelectListItems(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetProjectSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetServiceByProjectId(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetServiceByProjectId/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }


        public async Task<SelectList> GetAgriCalendarTypeSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriCalendarTypeSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetAgriCalendarCategorySelectListItems(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriCalendarCategorySelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetAgriCalendarProductSelectListItems(int id)
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriCalendarProductSelectListItems/" + id);

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetMonthSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetMonthSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetAgriCalendarWeekSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAgriCalendarWeekSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetEcologicalAreaSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetEcologicalAreaSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetMarketSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetMarketSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetAlbumSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetAlbumSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetPlaylistSelectListItems()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetPlaylistSelectListItems");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexValViewModel>());
        }
        public async Task<SelectList> GetSelectListRoles()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetSelectListRoles");

                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<List<CommonTexForStringIdValViewModel>>(response.Data.ToString());
                    return new SelectList(data, "value", "text");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }

            return new SelectList(new List<CommonTexForStringIdValViewModel>());
        }
        public async Task<OfficeMVCViewModel> GetOfficeDetail()
        {
            try
            {
                var response = await _globalVeriable.GetMethod("Admin/Utility/GetOfficeDetails");
                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<OfficeMVCViewModel>(response.Data.ToString());
                    return data;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during deserialization: {ex.Message}");
            }
            return new OfficeMVCViewModel();

        }
        private async Task<string> GetStringFromApi(string apiUrl)
        {
            try
            {
                var response = await _globalVeriable.GetMethod(apiUrl);
                if (response.Status)
                {
                    return response.Data?.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching string from API: {ex.Message}");
            }

            return string.Empty;
        }

        #region By ID Utilities

        public async Task<string> GetGenderNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetGenderName/{id}");

        public async Task<string> GetEducationNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetEducationName/{id}");

        public async Task<string> GetEducationLevelNameById(int? id) =>
            await GetStringFromApi($"Admin/Utility/GetEducationLevelName/{id}");

        public async Task<string> GetFarmerGroupNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetFarmerGroupName/{id}");

        public async Task<string> GetFarmerCategoryNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetFarmerCategoryName/{id}");

        public async Task<string> GetDistrictNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetDistrictName/{id}");

        public async Task<string> GetPalikaNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetPalikaName/{id}");

        public async Task<string> GetAvgMonthNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetAvgMonthName/{id}");

        public async Task<string> GetAgriSectorNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetAgriSectorName/{id}");

        public async Task<string> GetAgriServiceNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetAgriServiceName/{id}");

        public async Task<string> GetRelationNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetRelationName/{id}");

        public async Task<string> GetWorkingAreaNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetWorkingAreaName/{id}");

        public async Task<string> GetOwnershipNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetOwnershipName/{id}");

        public async Task<string> GetLandTypeNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetLandTypeName/{id}");

        public async Task<string> GetIrrigationSourceNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetIrrigationSourceName/{id}");

        public async Task<string> GetCropsTypeNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetCropsTypeName/{id}");

        public async Task<string> GetFruitsTypeNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetFruitsTypeName/{id}");

        public async Task<string> GetSeedsTypeNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetSeedsTypeName/{id}");

        public async Task<string> GetMushroomTypeNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetMushroomTypeName/{id}");

        public async Task<string> GetSilkTypeNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetSilkTypeName/{id}");

        public async Task<string> GetBeeTypeById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetBeeTypeName/{id}");

        public async Task<string> GetProcustionMeasurementNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetProcustionMeasurementName/{id}");

        public async Task<string> GetProcustionUseNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetProcustionUseName/{id}");

        public async Task<string> GetKrishiFarmTypeNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetKrishiFarmTypeName/{id}");

        public async Task<string> GetPostNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetPostName/{id}");

        public async Task<string> GetAgriGroupTypeNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetAgriGroupTypeName/{id}");

        public async Task<string> GetProgramNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetProgramName/{id}");

        public async Task<string> GetMeasuringUnitNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetMeasuringUnitName/{id}");

        public async Task<string> GetCategoryNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetCategoryName/{id}");

        public async Task<string> GetSubCategoryNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetSubCategoryName/{id}");

        public async Task<string> GetProjectNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetProjectName/{id}");

        public async Task<string> GetServiceNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetServiceName/{id}");

        public async Task<string> GetAgriCalendarTypeNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetAgriCalendarTypeName/{id}");

        public async Task<string> GetAgriCalendarCategoryNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetAgriCalendarCategoryName/{id}");

        public async Task<string> GetAgriCalendarProductNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetAgriCalendarProductName/{id}");

        public async Task<string> GetMonthNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetMonthName/{id}");

        public async Task<string> GetWeekNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetWeekName/{id}");

        public async Task<string> GetEcologicalAreaNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetEcologicalAreaName/{id}");

        public async Task<string> GetMarketNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetMarketName/{id}");

        public async Task<string> GetAlbumNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetAlbumName/{id}");

        public async Task<string> GetPlaylistNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetPlaylistName/{id}");

        public async Task<string> GetStateNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetStateName/{id}");

        public async Task<string> GetFiscalYearNameById(int id) =>
            await GetStringFromApi($"Admin/Utility/GetFiscalYearName/{id}");

        public async Task<string> GetBeeTypeNameById(int id)
       =>await GetStringFromApi($"Admin/Utility/GetBeeTypeNameById/{id}");

        public Task<bool> Delete(string tableName, int id)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}
