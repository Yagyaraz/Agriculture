using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Agriculture.Areas.Admin.Interface
{
    public interface ICommon
    {
        #region fiscalYear
        Task<List<FiscalYearViewModel>> GetAllFiscalYear();
        Task<FiscalYearViewModel> GetFiscalYearById(int id);
        Task<bool> InsertUpdateFiscalYear(FiscalYearViewModel model);
        #endregion
        #region Office
        Task<List<OfficeViewModel>> GetAllOffice();
        Task<OfficeViewModel> GetOfficeById(int id);
        Task<bool> InsertUpdateOffice(OfficeViewModel model);
        #endregion
        #region EducationLevel
        Task<List<CommonViewModel>> GetAllEducationLevel();
        Task<CommonViewModel> GetEducationLevelById(int id);
        Task<bool> InsertUpdateEducationLevel(CommonViewModel model);
        #endregion
        #region FarmerGroup
        Task<List<CommonViewModel>> GetAllFarmerGroup();
        Task<CommonViewModel> GetFarmerGroupById(int id);
        Task<bool> InsertUpdateFarmerGroup(CommonViewModel model);
        #endregion
        #region WardSetup
        Task<List<CommonViewModel>> GetAllWardSetup();
        Task<CommonViewModel> GetWardSetupById(int id);
        Task<bool> InsertUpdateWardSetup(CommonViewModel model);
        #endregion
        #region FarmerCategory
        Task<List<CommonViewModel>> GetAllFarmerCategory();
        Task<CommonViewModel> GetFarmerCategoryById(int id);
        Task<bool> InsertUpdateFarmerCategory(CommonViewModel model);
        #endregion
        #region AnimalSetup
        Task<List<AnimalSetupViewModel>> GetAllAnimalSetup();
        Task<bool> GetAnimalSetupById(BooleianViewModel model);
        Task<bool> InsertUpdateAnimalSetup(AnimalSetupViewModel model); 
        Task<SelectList> GetAllActiveAgriculture();
        #endregion
        #region UserList
        Task<ApiResponse> RegisterUser(RegisterViewModel model);

        Task<List<RegisterViewModel>> GetAllUserList(); 
        #endregion
    }
}
