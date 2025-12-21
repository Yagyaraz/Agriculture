using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IApplicationForm
    {
        Task<List<ApplicationFormViewModel>> GetAllApplicationForm();
        Task<ApplicationFormViewModel> GetApplicationFormById(int id);
        Task<bool> InsertUpdateApplicationForm(ApplicationFormViewModel model);
    }
}
