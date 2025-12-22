using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgricultureView.Areas.Admin.Models
{
    public class FarmerViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FullNameEng { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int PalikaId { get; set; }
        public int WardNo { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        public string Gender { get; set; }
        public string DOBNep { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOBEng { get; set; }
        public int EducationId { get; set; }
        public int? EducationLevelId { get; set; }
        public string TolName { get; set; }
        public string CitizenNo { get; set; }
        public int CitizenDistricrId { get; set; }
        public string CitizenIssueDate { get; set; }
        public int FarmerGroupId { get; set; }
        public int FarmerCategoryId { get; set; }
        public string HouseNo { get; set; }
        public KrishiDetailsViewModel krishi {  get; set; }=new KrishiDetailsViewModel();
        public FamilyDetailssViewModel Family {  get; set; }=new FamilyDetailssViewModel();
        public FieldDetailsViewModel Field {  get; set; }=new FieldDetailsViewModel();
        public CropsInformationViewModel CropsInformation {  get; set; }=new CropsInformationViewModel();
        public AnimalHusbandryViewModel Animal {  get; set; }=new AnimalHusbandryViewModel();
    }
    public class KrishiDetailsViewModel
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int FiscalYearId { get; set; }
        public bool IsSelfJagga { get; set; }
        public string ChooseLand { get; set; }
        public int? TotalBigaha { get; set; }
        public int? TotalKattha { get; set; }
        public int? TotalDhur { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalBigaSquareMiter { get; set; }
        public int? TotalRopani { get; set; }
        public int? TotalAana { get; set; }
        public int? TotalPaisa { get; set; }
        public int? TotalDam { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalRopaniSquareMiter { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? IncomeFromAgri { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? IncomeFromNonAgri { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? TotalIncome { get; set; }

        public int AvgMonthForAgriId { get; set; }
        public List<AgricultureDetailViewModel> AgricultureDetailViewModelList { get; set; } = new List<AgricultureDetailViewModel>();
    }
    public class AgricultureDetailViewModel
    {
        public int Id { get; set; }
        public int KrishiDetailsId { get; set; }
        public int AgriWardNo { get; set; }
        public string AgriAddress { get; set; }
        public int AgriSectorId { get; set; }
        public string AgriSubSector { get; set; }
    }

    public class FamilyDetailssViewModel
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int FiscalYearId { get; set; }

        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }
        public int TotalMember { get; set; }
        public int TotalMaleInAgri { get; set; }
        public int TotalFemaleInAgri { get; set; }
        public int TotalMemberInAgri { get; set; }

        public int TotalInvolvedinAgi { get; set; }

        public List<FamilyDetailsInvolvedInAgriViewModel> FamilyDetailInvolveList { get; set; } = new List<FamilyDetailsInvolvedInAgriViewModel>();
    }
    public class FamilyDetailsInvolvedInAgriViewModel
    {
        public int Id { get; set; }
        public int FamilyDetailsId { get; set; }
        public int RelationId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public int WorkingAreaId { get; set; }
        public string CitizenNo { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        public string PhoneNumbar { get; set; }
    }
    #region FieldDetails
    public class FieldDetailsViewModel
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int FiscalYearId { get; set; }

        public bool IsKrishakDarta { get; set; }
        public string DartaNo { get; set; }

        public string FullName { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string SanjhutaMiti { get; set; }
        public DateTime? SanjhutaDate { get; set; }
        public string SamjhutaEndMiti { get; set; }
        public DateTime SamjhutaEndDate { get; set; }
        public string CitizenNo { get; set; }
        public string CurrentAddress { get; set; }
        public List<LandOwnershipViewModel> LandOwnershipViewModelList { get; set; } = new List<LandOwnershipViewModel>();
        public List<AgriFarmMoreThanOneLocalLevelViewModel> AgriFarmMoreThanOneLocalLevelViewModelList { get; set; } = new List<AgriFarmMoreThanOneLocalLevelViewModel>();
        public List<LeasedLandDetailViewModel> LeasedLandDetailViewModelList { get; set; } = new List<LeasedLandDetailViewModel>();
    }
    public class LandOwnershipViewModel
    {
        public int Id { get; set; }
        public int FieldDetailsId { get; set; }
        public int OwnershipId { get; set; }
        public int LandTypeId { get; set; }
        public string Area { get; set; }
        public bool IsIrrigartionAvilable { get; set; }
        public string IrrigartionArea { get; set; }
        public int IrrigationSourceId { get; set; }
    }
    public class AgriFarmMoreThanOneLocalLevelViewModel
    {
        public int Id { get; set; }
        public int FieldDetailsId { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public bool IsIrrigationAvailiable { get; set; }
        public int SectorId { get; set; }
        public string SubSector { get; set; }
        public int OwnershipId { get; set; }
        public string DetailOfLandOwner { get; set; }
    }
    public class LeasedLandDetailViewModel
    {
        public int Id { get; set; }
        public int FieldDetailsId { get; set; }

        public int OwnershipId { get; set; }
        public int LandTypeId { get; set; }
        public string Area { get; set; }

        public bool IsIrrigartionAvilable { get; set; }
        public string IrrigartionArea { get; set; }
        public int IrrigationSourceId { get; set; }
    }
    #endregion
    #region Crop Information
    public class CropsInformationViewModel
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int FiscalYearId { get; set; }

        public List<EatableCropsViewModel> EatableCropsViewModelList { get; set; } = new List<EatableCropsViewModel>();
        public List<FruitCropsViewModel> FruitCropsViewModelList { get; set; } = new List<FruitCropsViewModel>();
        public List<SeedCropsViewModel> SeedCropsViewModelList { get; set; } = new List<SeedCropsViewModel>();
        public List<MushroomCrposViewModel> MushroomCrposViewModelList { get; set; } = new List<MushroomCrposViewModel>();
        public List<SilkCropsViewModel> SilkCropsViewModelList { get; set; } = new List<SilkCropsViewModel>();
        public List<BeeCropsViewModel> BeeCropsViewModelList { get; set; } = new List<BeeCropsViewModel>();
    }
    public class EatableCropsViewModel
    {
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public int CropsTypeId { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }
    }
    public class FruitCropsViewModel
    {
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public int FruitsTypeId { get; set; }
        public int TotalPlant { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }
    }
    public class SeedCropsViewModel
    {
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public int SeedsTypeId { get; set; }
        public string Jaat { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }
    }
    public class MushroomCrposViewModel
    {
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public int MushroomTypeId { get; set; }
        public int TotalCount { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }
    }
    public class SilkCropsViewModel
    {
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public string Area { get; set; }
        public int SilkTypeId { get; set; }
        public int TotalCount { get; set; }
    }
    public class BeeCropsViewModel
    {
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public int BeeTypeId { get; set; }
        public int TotalCount { get; set; }
        public int Quantity { get; set; }
    }

    #endregion
    #region Animal Husbandry
    public class AnimalHusbandryViewModel
    {
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int FiscalYearId { get; set; }

        public CowInfromationViewModel CowInfromationViewModelList { get; set; } = new CowInfromationViewModel();
        public BuffaloInfromationViewModel BuffaloInfromationViewModelList { get; set; } = new BuffaloInfromationViewModel();
        public CharuiYakInfromationViewModel CharuiYakInfromationViewModelList { get; set; } = new CharuiYakInfromationViewModel();
        public GoruInfromationViewModel GoruInfromationViewModelList { get; set; } = new GoruInfromationViewModel();
        public BhedaBakhraInfromationViewModel BhedaBakhraInfromationViewModelList { get; set; } = new BhedaBakhraInfromationViewModel();
        public BungurSungurInfromationViewModel BungurSungurInfromationViewModelList { get; set; } = new BungurSungurInfromationViewModel();
        public HenInfromationViewModel HenInfromationViewModelList { get; set; } = new HenInfromationViewModel();
        public OtherBirdInfromationViewModel OtherBirdInfromationViewModelList { get; set; } = new OtherBirdInfromationViewModel();
        public FishInfromationViewModel FishInfromationViewModelList { get; set; } = new FishInfromationViewModel();
        public OtherAnimalInfromationViewModel OtherAnimalInfromationViewModelList { get; set; } = new OtherAnimalInfromationViewModel();
        public GhaseBaliInfromationViewModel GhaseBaliInfromationViewModelList { get; set; } = new GhaseBaliInfromationViewModel();
        public KrishiFarmInfromationViewModel KrishiFarmInfromationViewModelList { get; set; } = new KrishiFarmInfromationViewModel();


        public List<KrishiSanrachanaInfromationViewModel> KrishiSanrachanaInfromationViewModelList { get; set; } = new List<KrishiSanrachanaInfromationViewModel>();
        public List<KrishiMechinaryInfromationViewModel> KrishiMechinaryInfromationViewModelList { get; set; } = new List<KrishiMechinaryInfromationViewModel>();
    }
    public class CowInfromationViewModel
    {
        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int CowLocCount { get; set; }
        public int CowLocMilkMonth { get; set; }
        public int CowLocMilkDaily { get; set; }
        public int CowUnnatCount { get; set; }
        public int CowUnnatMilkMonth { get; set; }
        public int CowUnnatMilkDaily { get; set; }
    }
    public class BuffaloInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int BuffLocCount { get; set; }
        public int BuffLocMilkMonth { get; set; }
        public int BuffLocMilkDaily { get; set; }
        public int BuffUnnatCount { get; set; }
        public int BuffUnnatMilkMonth { get; set; }
        public int BuffUnnatMilkDaily { get; set; }
    }
    public class CharuiYakInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        [Required]
        public int ChauriCount { get; set; }
        public int ChauriMilkMonth { get; set; }
        public int ChauriMilkDaily { get; set; }
        public int YakCount { get; set; }
        public int YakMilkMonth { get; set; }
        public int YakMilkDaily { get; set; }
    }
    public class GoruInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int GoruCount { get; set; }
        public int RagaCount { get; set; }
    }
    public class BhedaBakhraInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int BhedaCount { get; set; }
        public int BhedaKasiCount { get; set; }
        public int BhedaBokaCount { get; set; }
        public int BhedaPathaCount { get; set; }
        public int BakhraCount { get; set; }
        public int BakhraKasiCount { get; set; }
        public int BakhraBokaCount { get; set; }
        public int BakhraPathaCount { get; set; }
        public int ChangraCount { get; set; }
        public int ChangraKasiCount { get; set; }
        public int ChangraBokaCount { get; set; }
        public int ChangraPathaCount { get; set; }
    }
    public class BungurSungurInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int BungurCount { get; set; }
        public int BungurMaleCount { get; set; }
        public int BungurPathaCount { get; set; }
        public int SungurCount { get; set; }
        public int SungurMaleCount { get; set; }
        public int SungurPathaCount { get; set; }
        public int BadelCount { get; set; }
        public int BadelMaleCount { get; set; }
        public int BadelPathaCount { get; set; }

    }
    public class HenInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public bool IsLayers { get; set; }
        public int LayersCount { get; set; }
        public int LayersEggCount { get; set; }
        public int LayersChickenProductionCount { get; set; }
        public bool IsBoiler { get; set; }
        public int BoilerCount { get; set; }
        public int BoilerEggCount { get; set; }
        public int BoilerChickenProductionCount { get; set; }
    }
    public class OtherBirdInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int DuckCount { get; set; }
        public int DuckEggCount { get; set; }
        public int DuckProductionCount { get; set; }
        public int BattaiCount { get; set; }
        public int BattaiEggCount { get; set; }
        public int BattaiProductionCount { get; set; }
        public int AustrichCount { get; set; }
        public int AustrichEggCount { get; set; }
        public int AustrichProductionCount { get; set; }
        public int KalijCount { get; set; }
        public int KalijEggCount { get; set; }
        public int KalijProductionCount { get; set; }
        public int TurkeyCount { get; set; }
        public int TurkeyEggCount { get; set; }
        public int TurkeyProductionCount { get; set; }
        public int LaukatCount { get; set; }
        public int LaukatEggCount { get; set; }
        public int LaukatProductionCount { get; set; }
        public int PegionCount { get; set; }
        public int PegionEggCount { get; set; }
        public int PegionProductionCount { get; set; }
        public int OtherCount { get; set; }
        public int OtherEggCount { get; set; }
        public int OtherProductionCount { get; set; }
    }
    public class FishInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public bool IsRahu { get; set; }
        public bool IsNaini { get; set; }
        public bool IsSilvercarp { get; set; }
        public bool IsNaibigheadkarpni { get; set; }
        public bool IsGrasscarp { get; set; }
        public bool IsComoncarp { get; set; }
        public bool IsTrout { get; set; }
        public bool Ischadi { get; set; }
        public bool IsTilapiya { get; set; }
        public bool IsPangas { get; set; }
        public bool IsLocal { get; set; }
        public bool IsOther { get; set; }
        public int PondArea { get; set; }
        public int TotalCount { get; set; }
        public int? ProcustionUseId { get; set; }
        public int? ProcustionMeasurementId { get; set; }
        public int ProcustionQuantity { get; set; }
    }
    public class OtherAnimalInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int GhodaCount { get; set; }
        public int KhaccedCount { get; set; }
        public int GadhaCount { get; set; }
        public int RabbitCount { get; set; }
        public int DogCount { get; set; }
        public int CatCount { get; set; }
        public int OtherCount { get; set; }
    }
    public class GhaseBaliInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int HudeJaat { get; set; }
        public int HudeArea { get; set; }
        public int HudeGrassProd { get; set; }
        public int HudeSeedProd { get; set; }
        public int BarshaJaat { get; set; }
        public int BarshaArea { get; set; }
        public int BarshaGrassProd { get; set; }
        public int BarshaSeedProd { get; set; }
        public int BahuBarshaJaat { get; set; }
        public int BahuBarshaArea { get; set; }
        public int BahuBarshaGrassProd { get; set; }
        public int BahuBarshaSeedProd { get; set; }
        public int DaleJaat { get; set; }
        public int DaleArea { get; set; }
        public int DaleGrassProd { get; set; }
        public int DaleSeedProd { get; set; }
        public int NurseryJaat { get; set; }
        public int NurseryArea { get; set; }
        public int NurseryGrassProd { get; set; }
        public int NurserySeedProd { get; set; }
    }
    public class KrishiFarmInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        [Required]
        public string DartaNo { get; set; }
        [Required]
        public string DartaMiti { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string KaryalayeName { get; set; }
        [Required]
        public string PanNo { get; set; }
        [Required]
        public string ChairpersonName { get; set; }
        [Required]
        public int? KrishiFarmTypeId { get; set; }
        [Required]
        public int MemberCount { get; set; }
        [Required]
        public int EmploymentCount { get; set; }
    }
    public class KrishiMechinaryInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }

        public string MechinaryName { get; set; }
        public string Swamitya { get; set; }
        public int Potential { get; set; }
        public int TotalCount { get; set; }
    }
    public class KrishiSanrachanaInfromationViewModel
    {

        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }

        public string SanrachanaType { get; set; }
        public int ToalCount { get; set; }
        public string Area { get; set; }
    }
    #endregion
}
