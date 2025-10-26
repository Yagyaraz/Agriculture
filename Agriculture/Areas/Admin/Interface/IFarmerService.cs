using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IFarmerService
    {
        Task<List<FarmerServiceViewModel>> GetAllFarmerService();
        Task<FarmerServiceViewModel> GetFarmerServiceById(int id);
        Task<bool> InsertUpdateFarmerService(FarmerServiceViewModel model);


        Task<List<FarmerServiceCardViewModel>> GetAllFarmerServiceCard();
        Task<FarmerServiceCardViewModel> GetFarmerServiceCardById(int id);
        Task<bool> InsertUpdateFarmerServiceCard(FarmerServiceCardViewModel model);
    }
}
