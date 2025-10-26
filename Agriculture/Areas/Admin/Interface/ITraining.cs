using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface ITraining
    {
        Task<List<TrainingViewModel>> GetAllTraining();
        Task<TrainingViewModel> GetTrainingById(int id);
        Task<bool> InsertUpdateTraining(TrainingViewModel model);
    }
}
