using Agriculture.Models;
using Agriculture.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class UtilityController : ControllerBase
    {
        private readonly IUtility _Utility;
        public UtilityController(IUtility utility)
        {
            _Utility = utility;
        }
        [HttpDelete("delete")]
        public async Task<IActionResult> SoftDelete(
      [FromQuery] string tableName,
      [FromQuery] int id)
        {
            var result = await _Utility.Delete(tableName, id);

            if (!result)
                return BadRequest(new { message = "Soft delete failed" });

            return Ok(new { message = "Soft deleted successfully" });
        }
        [HttpGet("GetFarmerSelectListItems")]
        public async Task<IActionResult> GetFarmerSelectListItems()
        {
            var data = await _Utility.GetFarmerSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Farmer" : "Farmer list Not Generated Try Again", Data = data });
        }
        [HttpGet("GetWardNoSelectListItems")]
        public async Task<IActionResult> GetWardNoSelectListItems()
        {
            var data = await _Utility.GetWardNoSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Ward" : "Ward Not Generated Try Again", Data = data });
        }
        [HttpGet("GetStateSelectListItems")]
        public async Task<IActionResult> GetStateSelectListItems()
        {
            var data = await _Utility.GetStateSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of state" : "State Not Generated Try Again", Data = data });
        }
        [HttpGet("GetDistrictSelectListItems/{id}")]
        public async Task<IActionResult> GetDistrictSelectListItems(int id = 0)
        {
            var data = await _Utility.GetDistrictSelectListItems(id);
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of district" : "District Not Generated Try Again", Data = data });
        }
        [HttpGet("GetPalikaSelectListItems/{id}")]
        public async Task<IActionResult> GetPalikaSelectListItems(int id = 0)
        {
            var data = await _Utility.GetPalikaSelectListItems(id);
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of palika" : "Palika Not Generated Try Again", Data = data });
        }
        [HttpGet("GetPalikaEngSelectListItems/{id}")]
        public async Task<IActionResult> GetPalikaEngSelectListItems(int id = 0)
        {
            var data = await _Utility.GetPalikaEngSelectListItems(id);
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of palika" : "Palika Not Generated Try Again", Data = data });
        }

        [HttpGet("GetFiscalYearSelectListItems")]
        public async Task<IActionResult> GetFiscalYearSelectListItems()
        {
            var data = await _Utility.GetFiscalYearSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of FiscalYear" : "FiscalYear Not Generated Try Again", Data = data });
        }
        [HttpGet("GetGenderSelectListItems")]
        public async Task<IActionResult> GetGenderSelectListItems()
        {
            var data = await _Utility.GetGenderSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Gender" : "Gender Not Generated Try Again", Data = data });
        }
        [HttpGet("GetEducationSelectListItems")]
        public async Task<IActionResult> GetEducationSelectListItems()
        {
            var data = await _Utility.GetEducationSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Education" : "Education Not Generated Try Again", Data = data });
        }
        [HttpGet("GetEducationLevelSelectListItems")]
        public async Task<IActionResult> GetEducationLevelSelectListItems()
        {
            var data = await _Utility.GetEducationLevelSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Education Level" : "Education Level Not Generated Try Again", Data = data });
        }
        [HttpGet("GetFarmerGroupSelectListItems")]
        public async Task<IActionResult> GetFarmerGroupSelectListItems()
        {
            var data = await _Utility.GetFarmerGroupSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Farmer Group" : "Farmer Group Not Generated Try Again", Data = data });
        }
        [HttpGet("GetFarmerCategorySelectListItems")]
        public async Task<IActionResult> GetFarmerCategorySelectListItems()
        {
            var data = await _Utility.GetFarmerCategorySelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Farmer Category" : "Farmer Category Not Generated Try Again", Data = data });
        }
        [HttpGet("GetOnlyDistrictSelectListItems")]
        public async Task<IActionResult> GetOnlyDistrictSelectListItems()
        {
            var data = await _Utility.GetOnlyDistrictSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of District" : "District Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAvgmonthSelectListItems")]
        public async Task<IActionResult> GetAvgmonthSelectListItems()
        {
            var data = await _Utility.GetAvgmonthSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Avgmonth" : "AvgMonth Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriSectorSelectListItems")]
        public async Task<IActionResult> GetAgriSectorSelectListItems()
        {
            var data = await _Utility.GetAgriSectorSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriSector" : "Agrisector Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriServiceSelectListItems/{id}")]
        public async Task<IActionResult> GetAgriServiceSelectListItems(int id)
        {
            var data = await _Utility.GetAgriServiceSelectListItems(id);
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Agri Service" : "Agri Service Not Generated Try Again", Data = data });
        }
        [HttpGet("GetRelationSelectListItems")]
        public async Task<IActionResult> GetRelationSelectListItems()
        {
            var data = await _Utility.GetRelationSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Relation" : "Relation Not Generated Try Again", Data = data });
        }
        [HttpGet("GetWorkingAreaSelectListItems")]
        public async Task<IActionResult> GetWorkingAreaSelectListItems()
        {
            var data = await _Utility.GetWorkingAreaSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Working Area" : "Working Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetOwnershipSelectListItems")]
        public async Task<IActionResult> GetOwnershipSelectListItems()
        {
            var data = await _Utility.GetOwnershipSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Ownership" : "Ownership Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetLandTypeSelectListItems")]
        public async Task<IActionResult> GetLandTypeSelectListItems()
        {
            var data = await _Utility.GetLandTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Land Type" : "Land Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetIrrigationSourceSelectListItems")]
        public async Task<IActionResult> GetIrrigationSourceSelectListItems()
        {
            var data = await _Utility.GetIrrigationSourceSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Irrigation Source" : "Irrigation Source Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetCropsTypeSelectListItems")]
        public async Task<IActionResult> GetCropsTypeSelectListItems()
        {
            var data = await _Utility.GetCropsTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Crops Type" : "Crops Type Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetFruitsTypeSelectListItems")]
        public async Task<IActionResult> GetFruitsTypeSelectListItems()
        {
            var data = await _Utility.GetFruitsTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Fruit Type" : "Fruits Type Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetSeedsTypeSelectListItems")]
        public async Task<IActionResult> GetSeedsTypeSelectListItems()
        {
            var data = await _Utility.GetSeedsTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Seed Type" : "Seed Type Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetMushroomTypeSelectListItems")]
        public async Task<IActionResult> GetMushroomTypeSelectListItems()
        {
            var data = await _Utility.GetMushroomTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Mushroom Type" : "Mushroom Type Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetSilkTypeSelectListItems")]
        public async Task<IActionResult> GetSilkTypeSelectListItems()
        {
            var data = await _Utility.GetSilkTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Silk Type" : "Silk Type Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetBeeTypeSelectListItems")]
        public async Task<IActionResult> GetBeeTypeSelectListItems()
        {
            var data = await _Utility.GetBeeTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Bee Type" : "Bee Type Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetProcustionMeasurementSelectListItems")]
        public async Task<IActionResult> GetProcustionMeasurementSelectListItems()
        {
            var data = await _Utility.GetProcustionMeasurementSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Product Measurement" : "Product Measurement Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetProcustionUseSelectListItems")]
        public async Task<IActionResult> GetProcustionUseSelectListItems()
        {
            var data = await _Utility.GetProcustionMeasurementSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Product Use" : "Product Use Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetKrishiFarmTypeSelectListItems")]
        public async Task<IActionResult> GetKrishiFarmTypeSelectListItems()
        {
            var data = await _Utility.GetKrishiFarmTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Family Type" : "Family Type Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetPostSelectListItems")]
        public async Task<IActionResult> GetPostSelectListItems()
        {
            var data = await _Utility.GetPostSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Post" : "Post Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriGroupTypeSelectListItems")]
        public async Task<IActionResult> GetAgriGroupTypeSelectListItems()
        {
            var data = await _Utility.GetAgriGroupTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Agriculture Group" : "Agriculture Group Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetProgramSelectListItems")]
        public async Task<IActionResult> GetProgramSelectListItems()
        {
            var data = await _Utility.GetProgramSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Agriculture program" : "Agriculture program Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetMeasuringUnitSelectListItems")]
        public async Task<IActionResult> GetMeasuringUnitSelectListItems()
        {
            var data = await _Utility.GetMeasuringUnitSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Measuring Unit" : "Measuring Unit Type Area Not Generated Try Again", Data = data });
        }

        [HttpGet("GetProjectSelectListItems/{id}")]
        public async Task<IActionResult> GetProjectSelectListItems(int id)
        {
            var data = await _Utility.GetProjectSelectListItems(id);
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Agriculture Project" : "Agriculture Priject Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetServiceByProjectId/{id}")]
        public async Task<IActionResult> GetServiceByProjectId(int id)
        {
            var data = await _Utility.GetServiceByProjectId(id);
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Service" : "Service Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetCategorySelectListItems")]
        public async Task<IActionResult> GetCategorySelectListItems()
        {
            var data = await _Utility.GetCategorySelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Category" : "Category Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetSubCategorySelectListItems/{id}")]
        public async Task<IActionResult> GetSubCategorySelectListItems(int id)
        {
            var data = await _Utility.GetSubCategorySelectListItems(id);
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Sub-Category" : "Sub-Category Type Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriCalendarTypeSelectListItems")]
        public async Task<IActionResult> GetAgriCalendarTypeSelectListItems()
        {
            var data = await _Utility.GetAgriCalendarTypeSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendarType" : "AgriCalendarTypeType Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriCalendarCategorySelectListItems/{id}")]
        public async Task<IActionResult> GetAgriCalendarCategorySelectListItems(int id)
        {
            var data = await _Utility.GetAgriCalendarCategorySelectListItems(id);
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendar Category" : "AgriCalendarType Category Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriCalendarProductSelectListItems/{id}")]
        public async Task<IActionResult> GetAgriCalendarProductSelectListItems(int id)
        {
            var data = await _Utility.GetAgriCalendarProductSelectListItems(id);
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendar Product" : "AgriCalendarType Product Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetMonthSelectListItems")]
        public async Task<IActionResult> GetMonthSelectListItems()
        {
            var data = await _Utility.GetMonthSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendar Month" : "AgriCalendarType Month Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAgriCalendarWeekSelectListItems")]
        public async Task<IActionResult> GetAgriCalendarWeekSelectListItems()
        {
            var data = await _Utility.GetAgriCalendarWeekSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendar Week" : "AgriCalendarType Week Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetEcologicalAreaSelectListItems")]
        public async Task<IActionResult> GetEcologicalAreaSelectListItems()
        {
            var data = await _Utility.GetEcologicalAreaSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of AgriCalendar Ecological Area" : "Ecological Area Area Not Generated Try Again", Data = data });
        }
        [HttpGet("GetMarketSelectListItems")]
        public async Task<IActionResult> GetMarketSelectListItems()
        {
            var data = await _Utility.GetMarketSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Market List" : "Market List Not Generated Try Again", Data = data });
        }
        [HttpGet("GetAlbumSelectListItems")]
        public async Task<IActionResult> GetAlbumSelectListItems()
        {
            var data = await _Utility.GetAlbumSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Album" : "Album List Not Generated Try Again", Data = data });
        }
        [HttpGet("GetPlaylistSelectListItems")]
        public async Task<IActionResult> GetPlaylistSelectListItems()
        {
            var data = await _Utility.GetPlaylistSelectListItems();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of Playlist" : "Playlist List Not Generated Try Again", Data = data });
        }
        [HttpGet("GetSelectListRoles")]
        public async Task<IActionResult> GetSelectListRoles()
        {
            var data = await _Utility.GetSelectListRoles();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List of GetSelectListRoles" : "GetSelectListRoles List Not Generated Try Again", Data = data });
        }
        [HttpGet("GetOfficeDetails")]
        public async Task<IActionResult> GetOfficeDetails()
        {
            var data = await _Utility.GetOfficeDetails();
            return Ok(new ApiResponse { Status = data.Id > 0, Message = data.Id > 0 ? "Successfully Generated All List of GetSelectListRoles" : "GetSelectListRoles List Not Generated Try Again", Data = data });
        }
        private IActionResult BuildResponse(string data, string entityName)
        {
            return Ok(new ApiResponse
            {
                Status = !string.IsNullOrEmpty(data),
                Message = !string.IsNullOrEmpty(data) ? $"{entityName} retrieved successfully" : $"{entityName} not found",
                Data = data
            });
        }

        [HttpGet("GetGenderName/{id}")] public async Task<IActionResult> GetGenderName(int id) => BuildResponse(await _Utility.GetGenderNameById(id), "Gender");
        [HttpGet("GetEducationName/{id}")] public async Task<IActionResult> GetEducationName(int id) => BuildResponse(await _Utility.GetEducationNameById(id), "Education");
        [HttpGet("GetEducationLevelName/{id}")] public async Task<IActionResult> GetEducationLevelName(int id) => BuildResponse(await _Utility.GetEducationLevelNameById(id), "Education Level");
        [HttpGet("GetFarmerGroupName/{id}")] public async Task<IActionResult> GetFarmerGroupName(int id) => BuildResponse(await _Utility.GetFarmerGroupNameById(id), "Farmer Group");
        [HttpGet("GetFarmerCategoryName/{id}")] public async Task<IActionResult> GetFarmerCategoryName(int id) => BuildResponse(await _Utility.GetFarmerCategoryNameById(id), "Farmer Category");
        [HttpGet("GetDistrictName/{id}")] public async Task<IActionResult> GetDistrictName(int id) => BuildResponse(await _Utility.GetDistrictNameById(id), "District");
        [HttpGet("GetPalikaName/{id}")] public async Task<IActionResult> GetPalikaName(int id) => BuildResponse(await _Utility.GetPalikaNameById(id), "Palika");
        [HttpGet("GetAvgMonthName/{id}")] public async Task<IActionResult> GetAvgMonthName(int id) => BuildResponse(await _Utility.GetAvgMonthNameById(id), "Average Month");
        [HttpGet("GetAgriSectorName/{id}")] public async Task<IActionResult> GetAgriSectorName(int id) => BuildResponse(await _Utility.GetAgriSectorNameById(id), "Agri Sector");
        [HttpGet("GetAgriServiceName/{id}")] public async Task<IActionResult> GetAgriServiceName(int id) => BuildResponse(await _Utility.GetAgriServiceNameById(id), "Agri Service");
        [HttpGet("GetRelationName/{id}")] public async Task<IActionResult> GetRelationName(int id) => BuildResponse(await _Utility.GetRelationNameById(id), "Relation");
        [HttpGet("GetWorkingAreaName/{id}")] public async Task<IActionResult> GetWorkingAreaName(int id) => BuildResponse(await _Utility.GetWorkingAreaNameById(id), "Working Area");
        [HttpGet("GetOwnershipName/{id}")] public async Task<IActionResult> GetOwnershipName(int id) => BuildResponse(await _Utility.GetOwnershipNameById(id), "Ownership");
        [HttpGet("GetLandTypeName/{id}")] public async Task<IActionResult> GetLandTypeName(int id) => BuildResponse(await _Utility.GetLandTypeNameById(id), "Land Type");
        [HttpGet("GetIrrigationSourceName/{id}")] public async Task<IActionResult> GetIrrigationSourceName(int id) => BuildResponse(await _Utility.GetIrrigationSourceNameById(id), "Irrigation Source");
        [HttpGet("GetCropsTypeName/{id}")] public async Task<IActionResult> GetCropsTypeName(int id) => BuildResponse(await _Utility.GetCropsTypeNameById(id), "Crops Type");
        [HttpGet("GetFruitsTypeName/{id}")] public async Task<IActionResult> GetFruitsTypeName(int id) => BuildResponse(await _Utility.GetFruitsTypeNameById(id), "Fruits Type");
        [HttpGet("GetSeedsTypeName/{id}")] public async Task<IActionResult> GetSeedsTypeName(int id) => BuildResponse(await _Utility.GetSeedsTypeNameById(id), "Seeds Type");
        [HttpGet("GetMushroomTypeName/{id}")] public async Task<IActionResult> GetMushroomTypeName(int id) => BuildResponse(await _Utility.GetMushroomTypeNameById(id), "Mushroom Type");
        [HttpGet("GetSilkTypeName/{id}")] public async Task<IActionResult> GetSilkTypeName(int id) => BuildResponse(await _Utility.GetSilkTypeNameById(id), "Silk Type");
        [HttpGet("GetBeeTypeName/{id}")] public async Task<IActionResult> GetBeeTypeName(int id) => BuildResponse(await _Utility.GetBeeTypeNameById(id), "Bee Type");
        [HttpGet("GetProcustionMeasurementName/{id}")] public async Task<IActionResult> GetProcustionMeasurementName(int id) => BuildResponse(await _Utility.GetProcustionMeasurementNameById(id), "Procustion Measurement");
        [HttpGet("GetProcustionUseName/{id}")] public async Task<IActionResult> GetProcustionUseName(int id) => BuildResponse(await _Utility.GetProcustionUseNameById(id), "Procustion Use");
        [HttpGet("GetKrishiFarmTypeName/{id}")] public async Task<IActionResult> GetKrishiFarmTypeName(int id) => BuildResponse(await _Utility.GetKrishiFarmTypeNameById(id), "Krishi Farm Type");
        [HttpGet("GetPostName/{id}")] public async Task<IActionResult> GetPostName(int id) => BuildResponse(await _Utility.GetPostNameById(id), "Post");
        [HttpGet("GetAgriGroupTypeName/{id}")] public async Task<IActionResult> GetAgriGroupTypeName(int id) => BuildResponse(await _Utility.GetAgriGroupTypeNameById(id), "Agri Group Type");
        [HttpGet("GetProgramName/{id}")] public async Task<IActionResult> GetProgramName(int id) => BuildResponse(await _Utility.GetProgramNameById(id), "Program");
        [HttpGet("GetMeasuringUnitName/{id}")] public async Task<IActionResult> GetMeasuringUnitName(int id) => BuildResponse(await _Utility.GetMeasuringUnitNameById(id), "Measuring Unit");
        [HttpGet("GetCategoryName/{id}")] public async Task<IActionResult> GetCategoryName(int id) => BuildResponse(await _Utility.GetCategoryNameById(id), "Category");
        [HttpGet("GetSubCategoryName/{id}")] public async Task<IActionResult> GetSubCategoryName(int id) => BuildResponse(await _Utility.GetSubCategoryNameById(id), "SubCategory");
        [HttpGet("GetProjectName/{id}")] public async Task<IActionResult> GetProjectName(int id) => BuildResponse(await _Utility.GetProjectNameById(id), "Project");
        [HttpGet("GetServiceName/{id}")] public async Task<IActionResult> GetServiceName(int id) => BuildResponse(await _Utility.GetServiceNameById(id), "Service");
        [HttpGet("GetAgriCalendarTypeName/{id}")] public async Task<IActionResult> GetAgriCalendarTypeName(int id) => BuildResponse(await _Utility.GetAgriCalendarTypeNameById(id), "Agri Calendar Type");
        [HttpGet("GetAgriCalendarCategoryName/{id}")] public async Task<IActionResult> GetAgriCalendarCategoryName(int id) => BuildResponse(await _Utility.GetAgriCalendarCategoryNameById(id), "Agri Calendar Category");
        [HttpGet("GetAgriCalendarProductName/{id}")] public async Task<IActionResult> GetAgriCalendarProductName(int id) => BuildResponse(await _Utility.GetAgriCalendarProductNameById(id), "Agri Calendar Product");
        [HttpGet("GetMonthName/{id}")] public async Task<IActionResult> GetMonthName(int id) => BuildResponse(await _Utility.GetMonthNameById(id), "Month");
        [HttpGet("GetWeekName/{id}")] public async Task<IActionResult> GetWeekName(int id) => BuildResponse(await _Utility.GetWeekNameById(id), "Week");
        [HttpGet("GetEcologicalAreaName/{id}")] public async Task<IActionResult> GetEcologicalAreaName(int id) => BuildResponse(await _Utility.GetEcologicalAreaNameById(id), "Ecological Area");
        [HttpGet("GetMarketName/{id}")] public async Task<IActionResult> GetMarketName(int id) => BuildResponse(await _Utility.GetMarketNameById(id), "Market");
        [HttpGet("GetAlbumName/{id}")] public async Task<IActionResult> GetAlbumName(int id) => BuildResponse(await _Utility.GetAlbumNameById(id), "Album");
        [HttpGet("GetPlaylistName/{id}")] public async Task<IActionResult> GetPlaylistName(int id) => BuildResponse(await _Utility.GetPlaylistNameById(id), "Playlist");
        [HttpGet("GetStateName/{id}")] public async Task<IActionResult> GetStateName(int id) => BuildResponse(await _Utility.GetStateNameById(id), "State");
        [HttpGet("GetFiscalYearName/{id}")] public async Task<IActionResult> GetFiscalYearName(int id) => BuildResponse(await _Utility.GetFiscalYearNameById(id), "Fiscal Year");
    }
}

