using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class CropsInformation
    {
        [Key]
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int FiscalYearId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; }
    }
    public class EatableCrops
    {
        [Key]
        public int Id { get; set; } 
        public int CropsInformationId { get; set; }
        public int CropsTypeId { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(CropsInformationId))]
        public CropsInformation CropsInformation { get; set; }
        [ForeignKey(nameof(CropsTypeId))]
        public CropsType CropsType { get; set; }
    }
    public class FruitCrops
    {
        [Key]
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public int FruitsTypeId { get; set; }
        public int TotalPlant { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }



        [ForeignKey(nameof(CropsInformationId))]
        public CropsInformation CropsInformation { get; set; }
        [ForeignKey(nameof(FruitsTypeId))]
        public FruitsType FruitsType { get; set; }
    }
    public class SeedCrops
    {
        [Key]
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public int SeedsTypeId { get; set; }
        public string Jaat { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }


        [ForeignKey(nameof(CropsInformationId))]
        public CropsInformation CropsInformation { get; set; }
        [ForeignKey(nameof(SeedsTypeId))]
        public SeedsType SeedsType { get; set; }
    }
    public class MushroomCrpos
    {
        [Key]
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public int MushroomTypeId { get; set; }
        public int TotalCount { get; set; }
        public string Area { get; set; }
        public int Quantity { get; set; }


        [ForeignKey(nameof(CropsInformationId))]
        public CropsInformation CropsInformation { get; set; }

        [ForeignKey(nameof(MushroomTypeId))]
        public MushroomType MushroomType { get; set; }
    }
    public class SilkCrops
    {
        [Key]
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public string Area { get; set; }
        public int SilkTypeId { get; set; }
        public int TotalCount { get; set; }


        [ForeignKey(nameof(CropsInformationId))]
        public CropsInformation CropsInformation { get; set; }
        [ForeignKey(nameof(SilkTypeId))]
        public SilkType SilkType { get; set; }
    }
    public class BeeCrops
    {
        [Key]
        public int Id { get; set; }
        public int CropsInformationId { get; set; }
        public int BeeTypeId { get; set; }
        public int TotalCount { get; set; }
        public int Quantity { get; set; }


        [ForeignKey(nameof(CropsInformationId))]
        public CropsInformation CropsInformation { get; set; }
        [ForeignKey(nameof(BeeTypeId))]
        public BeeType BeeType { get; set; }
    }
    public class CropsType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class FruitsType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class SeedsType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class MushroomType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class SilkType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class BeeType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
}
