using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class Library
    {
        [Key]
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int CreatedWardId { get; set; }
        public DateTime? UpdatedDate { get; set; }


        [ForeignKey(nameof(TypeId))]
        public AgriSector AgriSector {  get; set; }
    }
}
