using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class FieldDetails
    {
        [Key]
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
        public DateTime SamjhutaEndDate{ get; set; }
        public string CitizenNo { get; set; }
        public string CurrentAddress { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; }
        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
    }
    public class LandOwnership
    {
        [Key]
        public int Id { get; set; }
        public int FieldDetailsId { get; set; }

        public int OwnershipId { get; set; }
        public int LandTypeId { get; set; }
        public string Area { get; set; }

        public bool IsIrrigartionAvilable { get; set; }
        public string IrrigartionArea { get; set; }
        public int IrrigationSourceId { get; set; }


        [ForeignKey(nameof(FieldDetailsId))]
        public FieldDetails FieldDetails { get; set; }
        [ForeignKey(nameof(OwnershipId))]
        public OwnershipType OwnershipType { get; set; }
        [ForeignKey(nameof(LandTypeId))]
        public LandType LandType { get; set; }
        [ForeignKey(nameof(IrrigationSourceId))]
        public IrrigationSource IrrigationSource { get; set; }
    }

    public class AgriFarmMoreThanOneLocalLevel
    {
        [Key]
        public int Id { get; set; }
        public int FieldDetailsId { get; set; }
        public string Address { get; set; }
        public string Area { get; set; }
        public bool IsIrrigationAvailiable { get; set; }
        public int SectorId { get; set; }
        public string SubSector { get; set; }
        public int OwnershipId { get; set; }
        public string DetailOfLandOwner { get; set; }

        [ForeignKey(nameof(FieldDetailsId))]
        public FieldDetails FieldDetails { get; set; }
        [ForeignKey(nameof(SectorId))]
        public AgriSector AgriSector { get; set; }
        [ForeignKey(nameof(OwnershipId))]
        public OwnershipType OwnershipType { get; set; }
    }
    public class LeasedLandDetail
    {
        [Key]
        public int Id { get; set; }
        public int FieldDetailsId { get; set; }

        public int OwnershipId { get; set; }
        public int LandTypeId { get; set; }
        public string Area { get; set; }

        public bool IsIrrigartionAvilable { get; set; }
        public string IrrigartionArea { get; set; }
        public int IrrigationSourceId { get; set; }


        [ForeignKey(nameof(FieldDetailsId))]
        public FieldDetails FieldDetails { get; set; }
        [ForeignKey(nameof(OwnershipId))]
        public OwnershipType OwnershipType { get; set; }
        [ForeignKey(nameof(LandTypeId))]
        public LandType LandType { get; set; }
        [ForeignKey(nameof(IrrigationSourceId))]
        public IrrigationSource IrrigationSource { get; set; }
    }
    public class OwnershipType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }

    public class LandType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class IrrigationSource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
}
