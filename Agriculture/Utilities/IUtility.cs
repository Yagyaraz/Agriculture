using Agriculture.Data;
using Agriculture.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agriculture.Utilities
{
    public interface IUtility
    {
        Task<SelectList> GetFarmerSelectListItems();
        Task<SelectList> GetWardNoSelectListItems();
        Task<SelectList> GetStateSelectListItems();
        Task<int> GetWardNoForLogin_Role_User();
        Task<int> GetWardNoForLogin_Role_FarmerId();
        Task<SelectList> GetDistrictSelectListItems(int? stateId);
        Task<SelectList> GetPalikaSelectListItems(int? distId);
        Task<SelectList> GetPalikaEngSelectListItems(int? distId);
        Task<SelectList> GetFiscalYearSelectListItems();
        Task<SelectList> GetGenderSelectListItems();
        Task<SelectList> GetEducationSelectListItems();
        Task<SelectList> GetEducationLevelSelectListItems();
        Task<SelectList> GetFarmerGroupSelectListItems();
        Task<SelectList> GetFarmerCategorySelectListItems();
        Task<SelectList> GetOnlyDistrictSelectListItems();
        Task<SelectList> GetAvgmonthSelectListItems();
        Task<SelectList> GetAgriSectorSelectListItems();
        Task<int> GetCurrentFiscalYearId();

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
        Task<SelectList> GetMeasuringUnitSelectListItems();
        Task<SelectList> GetCategorySelectListItems();
        Task<SelectList> GetSubCategorySelectListItems(int id);
        Task<SelectList> GetProjectSelectListItems(int id);
        Task<SelectList> GetServiceByProjectId(int id);
        Task<FileUploadModel> UploadImgReturnPathAndName(string folderName, IFormFile img, string name);
        Task RemoveFileFormServer(string path);




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
