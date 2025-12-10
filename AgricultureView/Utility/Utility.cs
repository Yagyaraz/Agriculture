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


        public async Task<LoginResponse> GetSessionDetails()
        {
            try
            {
                var session = _httpContextAccessor.HttpContext.Session.GetString("user");
                var data = JsonConvert.DeserializeObject<LoginResponse>(session.ToString());
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
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
    }
}
