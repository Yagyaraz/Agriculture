using System.ComponentModel.DataAnnotations;

namespace AgricultureView.Areas.Admin.Models
{
    public class TrainingViewModel
    {
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public string Title { get; set; }
        public string TrainerName { get; set; }
        public string TrainingPlace { get; set; }
        public int PremiumId { get; set; }
        public decimal? Amount { get; set; }

        public int TrainingTypeId { get; set; }
        public string StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDateEng { get; set; }
        public string EndDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDateEng { get; set; }
        public IFormFile FilePoto { get; set; }

        public string Organizer { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public string TrainingTypeName { get; set; }
        public string PremiumName { get; set; }
    }
}
