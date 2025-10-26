using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IAgriculturePlan
    {
        #region Program
        Task<List<AgricultureProgramViewModel>> GetAllProgram();
        Task<AgricultureProgramViewModel> GetProgramById(int id);
        Task<bool> InsertUpdateProgram(AgricultureProgramViewModel model);
        #endregion

        #region Project
        Task<List<AgricultureProjectViewModel>> GetAllProject();
        Task<AgricultureProjectViewModel> GetProjectById(int id);
        Task<bool> InsertUpdateProject(AgricultureProjectViewModel model);
        #endregion

        #region Service
        Task<List<AgricultureServiceViewModel>> GetAllService();
        Task<AgricultureServiceViewModel> GetServiceById(int id);
        Task<bool> InsertUpdateService(AgricultureServiceViewModel model);
        #endregion

        #region ApplicatoionForm
        Task<List<AgricultureApplicatoionFormFileViewModel>> GetAllApplicatoionForm();
        Task<AgricultureApplicatoionFormFileViewModel> GetApplicatoionFormById(int id);
        Task<bool> InsertUpdateApplicatoionForm(AgricultureApplicatoionFormViewModel model);
        #endregion
    }
}
