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

    }
}
