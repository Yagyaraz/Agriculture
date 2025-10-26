using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class Training
    {
        [Key]
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public string Title { get; set; }
        public string TrainerName { get; set; }
        public string TrainingPlace { get; set; }
        public int PremiumId { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { get; set; }

        public int TrainingTypeId { get; set; }
        public string StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDateEng { get; set; }
        public string EndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDateEng { get; set; }

        public string Organizer { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }

        public int CreatedWardId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set;}
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }


        [ForeignKey(nameof(TrainingTypeId))]
        public AgriSector AgriSector { get; set; }
        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
    }
}
