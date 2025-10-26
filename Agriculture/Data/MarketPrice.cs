using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class Market
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int CreatedWardId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class MarketPrice
    {
        [Key]
        public int Id { get; set; }
        public int MarketId { get; set; }
        public string Date { get; set; }
        public DateTime? DateEng { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public int CreatedWardId { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(MarketId))]
        public Market Market { get; set; }
    }
    public class MarketPriceDetails
    {
        [Key]
        public int Id { get; set; }
        public int MarketPriceId { get; set; }

        public string ProductName { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal RetailPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal WholesalePrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal AveragePrice { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey(nameof(MarketPriceId))]
        public MarketPrice MarketPrice { get; set; }
    }
}
