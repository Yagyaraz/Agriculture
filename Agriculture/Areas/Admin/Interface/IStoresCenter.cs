using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IStoresCenter
    {
        Task<List<FertilizerStoreViewModel>> GetAllFertilizerStore();
        Task<FertilizerStoreViewModel> GetFertilizerStoreById(int id);
        Task<bool> InsertUpdateFertilizerStore(FertilizerStoreViewModel model);
        
        #region SeedStore
        Task<List<SeedStoreViewModel>> GetAllSeedStore();
        Task<SeedStoreViewModel> GetSeedStoreById(int id);
        Task<bool> InsertUpdateSeedStore(SeedStoreViewModel model); 
        #endregion
        #region InsuranceCenter
        Task<List<InsuranceCenterViewModel>> GetAllInsuranceCenter();
        Task<InsuranceCenterViewModel> GetInsuranceCenterById(int id);
        Task<bool> InsertUpdateInsuranceCenter(InsuranceCenterViewModel model); 
        #endregion
        #region AgricultureEquipment
        Task<List<AgricultureEquipmentViewModel>> GetAllAgricultureEquipment();
        Task<AgricultureEquipmentViewModel> GetAgricultureEquipmentById(int id);
        Task<bool> InsertUpdateAgricultureEquipment(AgricultureEquipmentViewModel model); 
        #endregion
    }
}
