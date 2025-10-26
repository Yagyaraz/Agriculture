
namespace Agriculture.Areas.Admin.Models
{
    public class MarketPriceViewModel
    {
        public int Id { get; set; }
        public int MarketId { get; set; }
        public string Date { get; set; }
        public DateTime? DateEng { get; set; }
        public List<MarketPriceDetailsViewModel> MarketPriceDetailsViewModelList { get; set; } = new List<MarketPriceDetailsViewModel>();

        public string MarketName { get; set; }

    }
    public class MarketPriceDetailsViewModel
    {
        public int Id { get; set; }
        public int MarketPriceId { get; set; }

        public string ProductName { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholesalePrice { get; set; }
        public decimal AveragePrice { get; set; }
    }
}
