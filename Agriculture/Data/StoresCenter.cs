using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Agriculture.Data
{
    public class FertilizerStore
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string FilePath { get; set; }
        public int CreatedWardId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class FertilizerStoreProduction
    {
        [Key]
        public int Id { get; set; }
        public int FertilizerStoreId { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FertilizerStoreId))]
        public FertilizerStore FertilizerStore { get; set; }
        [ForeignKey(nameof(TypeId))]
        public AgriCalendarType AgriCalendarType { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public AgriCalendarCategory AgriCalendarCategory { get; set; }
        [ForeignKey(nameof(ProductId))]
        public AgriCalendarProduct AgriCalendarProduct { get; set; }
    }
    public class FertilizerStoreContactPerson
    {
        [Key]
        public int Id { get; set; }
        public int FertilizerStoreId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FertilizerStoreId))]
        public FertilizerStore FertilizerStore { get; set; }
    }
    public class SeedStore
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string FilePath { get; set; }

        public int CreatedWardId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class SeedStoreProduction
    {
        [Key]
        public int Id { get; set; }
        public int SeedStoreId { get; set; }
        public int TypeId { get; set; }
        public int CategoryId { get; set; }
        public int ProductId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(SeedStoreId))]
        public SeedStore SeedStore { get; set; }
        [ForeignKey(nameof(TypeId))]
        public AgriCalendarType AgriCalendarType { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public AgriCalendarCategory AgriCalendarCategory { get; set; }
        [ForeignKey(nameof(ProductId))]
        public AgriCalendarProduct AgriCalendarProduct { get; set; }
    }
    public class SeedStoreContactPerson
    {
        [Key]
        public int Id { get; set; }
        public int SeedStoreId { get; set; }
        public string Name { get; set; }
        public string PhoneNo { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(SeedStoreId))]
        public SeedStore SeedStore { get; set; }
    }

    public class InsuranceCenter
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string FilePath { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int CreatedWardId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class AgricultureEquipment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNo { get; set; }
        public string Address { get; set; }
        public string FilePath { get; set; }
        public int CreatedWardId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
