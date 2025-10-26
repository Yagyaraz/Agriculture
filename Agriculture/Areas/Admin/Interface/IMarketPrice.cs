using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IMarketPrice
    {
        #region Market
        Task<List<CommonViewModel>> GetAllMarket();
        Task<CommonViewModel> GetMarketById(int id);
        Task<bool> InsertUpdateMarket(CommonViewModel model);
        #endregion
        #region MarketPrice
        Task<List<MarketPriceViewModel>> GetAllMarketPrice();
        Task<MarketPriceViewModel> GetMarketPriceById(int id);
        Task<bool> InsertUpdateMarketPrice(MarketPriceViewModel model);
        #endregion
    }
}
