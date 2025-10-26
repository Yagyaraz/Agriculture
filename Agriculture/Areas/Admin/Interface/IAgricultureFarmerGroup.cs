using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IAgricultureFarmerGroup
    {
        Task<List<AgricultureFarmerGroupViewModel>> GetAllAgricultureFarmerGroup();
        Task<AgricultureFarmerGroupViewModel> GetAgricultureFarmerGroupById(int id);
        Task<bool> InsertUpdateAgricultureFarmerGroup(AgricultureFarmerGroupViewModel model);
    }
}
