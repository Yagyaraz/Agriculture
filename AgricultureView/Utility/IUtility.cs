using AgricultureView.Areas.Admin.Models;
using AgricultureView.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using static AgricultureView.Controllers.AccountController;

namespace AgricultureView.Utility
{
    public interface IUtility
    {
        Task<LoginResponse> GetSessionDetails();

        Task<SelectList> GetFarmerSelectListItems();
        Task<SelectList> GetWardNoSelectListItems();
        Task<SelectList> GetStateSelectListItems();
        Task<SelectList> GetDistrictSelectListItems(int id);
        Task<SelectList> GetPalikaSelectListItems(int id);
        Task<SelectList> GetPalikaEngSelectListItems(int id);
        Task<SelectList> GetFiscalYearSelectListItems();
        Task<SelectList> GetGenderSelectListItems();
        Task<SelectList> GetEducationSelectListItems();
        Task<SelectList> GetEducationLevelSelectListItems();
        Task<SelectList> GetFarmerGroupSelectListItems();
        Task<SelectList> GetOnlyDistrictSelectListItems();
        Task<SelectList> GetFarmerCategorySelectListItems();
        Task<SelectList> GetAvgmonthSelectListItems();
        Task<SelectList> GetAgriSectorSelectListItems();
        Task<SelectList> GetAgriServiceSelectListItems(int id);
        Task<SelectList> GetRelationSelectListItems();
        Task<SelectList> GetWorkingAreaSelectListItems();
        Task<SelectList> GetOwnershipSelectListItems();
        Task<SelectList> GetLandTypeSelectListItems();
        Task<SelectList> GetIrrigationSourceSelectListItems();
        Task<SelectList> GetCropsTypeSelectListItems();
        Task<SelectList> GetFruitsTypeSelectListItems();
        Task<SelectList> GetSeedsTypeSelectListItems();
        Task<SelectList> GetMushroomTypeSelectListItems();
        Task<SelectList> GetSilkTypeSelectListItems();
        Task<SelectList> GetBeeTypeSelectListItems();
        Task<SelectList> GetProcustionMeasurementSelectListItems();
        Task<SelectList> GetProcustionUseSelectListItems();
        Task<SelectList> GetKrishiFarmTypeSelectListItems();
        Task<SelectList> GetPostSelectListItems();
        Task<SelectList> GetAgriGroupTypeSelectListItems();
        Task<SelectList> GetProgramSelectListItems();
        Task<SelectList> GetProjectSelectListItems(int id);
        Task<SelectList> GetServiceByProjectId(int id);
        Task<SelectList> GetMeasuringUnitSelectListItems();
        Task<SelectList> GetCategorySelectListItems();
        Task<SelectList> GetSubCategorySelectListItems(int id);



        Task<SelectList> GetAgriCalendarTypeSelectListItems();
        Task<SelectList> GetAgriCalendarCategorySelectListItems(int id);
        Task<SelectList> GetAgriCalendarProductSelectListItems(int id);



        Task<SelectList> GetMonthSelectListItems();
        Task<SelectList> GetAgriCalendarWeekSelectListItems();
        Task<SelectList> GetEcologicalAreaSelectListItems();


        Task<SelectList> GetMarketSelectListItems();
        Task<SelectList> GetAlbumSelectListItems();
        Task<SelectList> GetPlaylistSelectListItems();
        Task<SelectList> GetSelectListRoles();
        Task<OfficeMVCViewModel> GetOfficeDetail();
        Task<string> GetGenderNameById(int id);
        Task<string> GetEducationNameById(int id);
        Task<string> GetEducationLevelNameById(int? id);
        Task<string> GetFarmerGroupNameById(int id);
        Task<string> GetFarmerCategoryNameById(int id);
        Task<string> GetDistrictNameById(int id);
        Task<string> GetPalikaNameById(int id);
        Task<string> GetAvgMonthNameById(int id);
        Task<string> GetAgriSectorNameById(int id);
        Task<string> GetAgriServiceNameById(int id);
        Task<string> GetRelationNameById(int id);
        Task<string> GetWorkingAreaNameById(int id);
        Task<string> GetOwnershipNameById(int id);
        Task<string> GetLandTypeNameById(int id);
        Task<string> GetIrrigationSourceNameById(int id);
        Task<string> GetCropsTypeNameById(int id);
        Task<string> GetFruitsTypeNameById(int id);
        Task<string> GetSeedsTypeNameById(int id);
        Task<string> GetMushroomTypeNameById(int id);
        Task<string> GetSilkTypeNameById(int id);
        Task<string> GetBeeTypeNameById(int id);
        Task<string> GetProcustionMeasurementNameById(int id);
        Task<string> GetProcustionUseNameById(int id);
        Task<string> GetKrishiFarmTypeNameById(int id);
        Task<string> GetPostNameById(int id);
        Task<string> GetAgriGroupTypeNameById(int id);
        Task<string> GetProgramNameById(int id);
        Task<string> GetMeasuringUnitNameById(int id);
        Task<string> GetCategoryNameById(int id);
        Task<string> GetSubCategoryNameById(int id);
        Task<string> GetProjectNameById(int id);
        Task<string> GetServiceNameById(int id);
        Task<string> GetAgriCalendarTypeNameById(int id);
        Task<string> GetAgriCalendarCategoryNameById(int id);
        Task<string> GetAgriCalendarProductNameById(int id);
        Task<string> GetMonthNameById(int id);
        Task<string> GetWeekNameById(int id);
        Task<string> GetEcologicalAreaNameById(int id);
        Task<string> GetMarketNameById(int id);
        Task<string> GetAlbumNameById(int id);
        Task<string> GetPlaylistNameById(int id);
        Task<string> GetStateNameById(int id);
        Task<string> GetFiscalYearNameById(int id);
    }
}
