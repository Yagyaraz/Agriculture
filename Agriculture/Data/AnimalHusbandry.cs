using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class AnimalHusbandry
    {
        [Key]
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int FiscalYearId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; }
        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
    }
    public class CowInfromation
    {
        [Key]
        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int CowLocCount { get; set; }
        public int CowLocMilkMonth { get; set; }
        public int CowLocMilkDaily { get; set; }
        public int CowUnnatCount { get; set; }
        public int CowUnnatMilkMonth { get; set; }
        public int CowUnnatMilkDaily { get; set; }

        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }
    public class BuffaloInfromation
    {
        [Key]
        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int BuffLocCount { get; set; }
        public int BuffLocMilkMonth { get; set; }
        public int BuffLocMilkDaily { get; set; }
        public int BuffUnnatCount { get; set; }
        public int BuffUnnatMilkMonth { get; set; }
        public int BuffUnnatMilkDaily { get; set; }

        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }
    public class CharuiYakInfromation
    {
        [Key]
        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int ChauriCount { get; set; }
        public int ChauriMilkMonth { get; set; }
        public int ChauriMilkDaily { get; set; }
        public int YakCount { get; set; }
        public int YakMilkMonth { get; set; }
        public int YakMilkDaily { get; set; }

        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }
    public class GoruInfromation
    {
        [Key]
        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int GoruCount { get; set; }
        public int RagaCount { get; set; }

        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }
    public class BhedaBakhraInfromation
    {
        [Key]
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

        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }
    public class BungurSungurInfromation
    {
        [Key]
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



        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }
    public class HenInfromation
    {
        [Key]
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


        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }    
    public class OtherBirdInfromation
    {
        [Key]
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


        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }    
    public class FishInfromation
    {
        [Key]
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


        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
        [ForeignKey(nameof(ProcustionUseId))]
        public ProcustionUse ProcustionUse { get; set; }
        [ForeignKey(nameof(ProcustionMeasurementId))]
        public ProcustionMeasurement ProcustionMeasurement { get; set; }
    }   
    public class OtherAnimalInfromation
    {
        [Key]
        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public int GhodaCount { get; set; }
        public int KhaccedCount { get; set; }
        public int GadhaCount { get; set; }
        public int RabbitCount { get; set; }
        public int DogCount { get; set; }
        public int CatCount { get; set; }
        public int OtherCount { get; set; }


        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }  
    public class GhaseBaliInfromation
    {
        [Key]
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


        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }
    public class KrishiFarmInfromation
    {
        [Key]
        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }
        public string DartaNo { get; set; }
        public string DartaMiti { get; set; }
        public string Name { get; set; }
        public string KaryalayeName { get; set; }
        public string PanNo { get; set; }
        public string ChairpersonName { get; set; }
        public int? KrishiFarmTypeId { get; set; }
        public int MemberCount { get; set; }
        public int EmploymentCount { get; set; }


        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
        [ForeignKey(nameof(KrishiFarmTypeId))]
        public KrishiFarmType KrishiFarmType { get; set; }
    }
    public class KrishiMechinaryInfromation
    {
        [Key]
        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }

        public string MechinaryName { get; set; }
        public string Swamitya { get; set; }
        public int Potential { get; set; }
        public int TotalCount { get; set; }


        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }
    public class KrishiSanrachanaInfromation
    {
        [Key]
        public int Id { get; set; }
        public int AnimalHusbandryId { get; set; }

        public string SanrachanaType { get; set; }
        public int ToalCount { get; set; }
        public string Area { get; set; }


        [ForeignKey(nameof(AnimalHusbandryId))]
        public AnimalHusbandry AnimalHusbandry { get; set; }
    }
    public class KrishiFarmType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ProcustionUse
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
    
    public class ProcustionMeasurement
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
