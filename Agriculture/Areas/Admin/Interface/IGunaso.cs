using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IGunaso
    {
        Task<GunasoViewModel> GetGunasoById(int id);
        Task<bool> CreateGunaso(GunasoViewModel model);
        Task<List<GunasoViewModel>> GunasoList();
    }
}
