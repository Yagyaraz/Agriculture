using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class KrishiDetails
    {
        [Key]
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

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; }
        [ForeignKey(nameof(AvgMonthForAgriId))]
        public AvgMonth AvgMonth { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
    public class AgricultureDetail
    {
        [Key]
        public int Id { get; set; }
        public int KrishiDetailsId { get; set; }
        public int AgriWardNo { get; set; }
        public string AgriAddress { get; set; }
        public int AgriSectorId { get; set; }
        public string AgriSubSector { get; set; }

        [ForeignKey(nameof(AgriSectorId))]
        public AgriSector AgriSector { get; set; }
        [ForeignKey(nameof(KrishiDetailsId))]
        public KrishiDetails KrishiDetails { get; set; }
    }
    public class AvgMonth
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class AgriSector
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class AgriService
    {
        [Key]
        public int Id { get; set; }
        public int AgriSectorId { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
