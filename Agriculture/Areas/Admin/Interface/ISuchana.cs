using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface ISuchana
    {
        Task<List<SuchanaViewModel>> GetAllSuchana();
        Task<SuchanaViewModel> GetSuchanaById(int id);
        Task<bool> InsertUpdateSuchana(SuchanaViewModel model);
    }
}
