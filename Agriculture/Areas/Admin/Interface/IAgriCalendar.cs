using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IAgriCalendar
    {
        #region AgriCalendarType

        Task<List<AgriCalendarTypeViewModel>> GetAllAgriCalendarType();
        Task<AgriCalendarTypeViewModel> GetAgriCalendarTypeById(int id);
        Task<bool> InsertUpdateAgriCalendarType(AgriCalendarTypeViewModel model); 
        #endregion
        #region AgriCalendarCategory

        Task<List<AgriCalendarCategoryViewModel>> GetAllAgriCalendarCategory();
        Task<AgriCalendarCategoryViewModel> GetAgriCalendarCategoryById(int id);
        Task<bool> InsertUpdateAgriCalendarCategory(AgriCalendarCategoryViewModel model); 
        #endregion
        #region AgriCalendarProduct

        Task<List<AgriCalendarProductViewModel>> GetAllAgriCalendarProduct();
        Task<AgriCalendarProductViewModel> GetAgriCalendarProductById(int id);
        Task<bool> InsertUpdateAgriCalendarProduct(AgriCalendarProductViewModel model); 
        #endregion
        #region AgriCalendar

        Task<List<AgriCalendarViewModel>> GetAllAgriCalendar();
        Task<AgriCalendarViewModel> GetAgriCalendarById(int id);
        Task<bool> InsertUpdateAgriCalendar(AgriCalendarViewModel model); 
        #endregion
    }
}
