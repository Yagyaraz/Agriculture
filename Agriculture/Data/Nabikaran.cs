using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class Nabikaran
    {
        public int Id { get; set; }
        public string RenewDate {  get; set; }
        public string ExpireDate {  get; set; }
        public string ReneweFee { get; set; }
        public string Fine { get; set; }
        public string RasidNumber { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int FirmId {  get; set; }
        [ForeignKey(nameof(FirmId))]
        public AgricultureFarmerGroup FarmerGroup { get; set; }
    }
}
