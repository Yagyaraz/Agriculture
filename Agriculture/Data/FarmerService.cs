using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Agriculture.Data
{

    public class FarmerServiceCard
    {
        [Key]
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public string ServiceDate { get; set; }
        public int FarmerId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedWardId { get; set; }


        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; }
        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
    }
    public class FarmerServiceCardDetail
    {
        [Key]
        public int Id { get; set; }
        public int FarmerServiceCardId { get; set; }
        public int TypeId { get; set; }
        public int ServiceId { get; set; }
        public int UnitId { get; set; }
        [Column(TypeName = "decimal(18, 3)")]
        public decimal Quantity { get; set; }
        public string Detail { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }


        [ForeignKey(nameof(FarmerServiceCardId))]
        public FarmerServiceCard FarmerServiceCard { get; set; }
        [ForeignKey(nameof(TypeId))]
        public AgriSector AgriSector { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public AgriService AgriService { get; set; }
        [ForeignKey(nameof(UnitId))]
        public MeasuringUnit MeasuringUnit { get; set; }
    }
}
