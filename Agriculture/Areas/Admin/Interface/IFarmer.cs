using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IFarmer
    {
        Task<List<FarmerViewModel>> GetAllFarmer();
        Task<FarmerViewModel> GetFarmerById(int id);
        Task<(bool, int newId)> InsertUpdateFarmer(FarmerViewModel model);


        Task<KrishiDetailsViewModel> GetKrishiDetail(int id);
        Task<bool> InsertUpdateKrishiDetail(KrishiDetailsViewModel model);


        Task<FamilyDetailssViewModel> GetFamilyDetails(int id);
        Task<bool> InsertUpdateFamilyDetails(FamilyDetailssViewModel model);


        Task<FieldDetailsViewModel> GetFieldDetails(int id);
        Task<bool> InsertUpdateFieldDetails(FieldDetailsViewModel model);


        Task<CropsInformationViewModel> GetCropsInformation(int id);
        Task<bool> InsertUpdateCropsInformation(CropsInformationViewModel model);


        Task<AnimalHusbandryViewModel> GetAnimalHusbandry(int id);
        Task<bool> InsertUpdateAnimalHusbandry(AnimalHusbandryViewModel model);
    }
}
