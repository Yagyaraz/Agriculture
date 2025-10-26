using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface ISubsidy
    {
        #region Category
        Task<List<CategoryViewModel>> GetAllCategory();
        Task<CategoryViewModel> GetCategoryById(int id);
        Task<bool> InsertUpdateCategory(CategoryViewModel model);
        #endregion
        #region SubCategory
        Task<List<SubCategoryViewModel>> GetAllSubCategory();
        Task<SubCategoryViewModel> GetSubCategoryById(int id);
        Task<bool> InsertUpdateSubCategory(SubCategoryViewModel model);
        #endregion
        #region Subsidy
        Task<List<SubsidyViewModel>> GetAllSubsidyForUser();
        Task<List<SubsidyViewModel>> GetAllSubsidy();
        Task<SubsidyViewModel> GetSubsidyById(int id);
        Task<SubsidyPopupViewModel> GetSubsidyByIdForPopUp(int id);
        Task<bool> InsertUpdateSubsidy(SubsidyViewModel model);
        Task<bool> SaveRequestedSubsidy(List<SaveRequestedSubsidyViewModel> model);
        #endregion
        #region OtherSubsidy
        Task<List<OtherSubsidyViewModel>> GetAllOtherSubsidy();
        Task<OtherSubsidyViewModel> GetOtherSubsidyById(int id);
        Task<bool> InsertUpdateOtherSubsidy(OtherSubsidyViewModel model);
        #endregion
    }
}
