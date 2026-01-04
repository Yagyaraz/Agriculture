using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class SaveRequestedSubsidy
    {
        public int Id { get; set; }
        public int SubsidyId { get; set; }
        public int SubsidyDetailId { get; set; }
        public int Quantity { get; set; }
        public int TotalRequired { get; set; }
        public int CreatedWardId { get; set; }
        public int FarmerId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; }
    }
}
