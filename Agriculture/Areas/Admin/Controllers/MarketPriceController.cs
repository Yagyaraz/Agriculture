using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class MarketPriceController : ControllerBase
    {
        private readonly IMarketPrice _MarketPrice;
        public MarketPriceController(IMarketPrice marketPrice)
        {
            _MarketPrice = marketPrice;
        }
        #region Market

        [HttpGet("GetAllMarket")]
        public async Task<IActionResult> GetAllMarket()
        {
            var data = await _MarketPrice.GetAllMarket();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetMarketById/{id}")]
        public async Task<IActionResult> GetMarketById(int id = 0)
        {
            var data = await _MarketPrice.GetMarketById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateMarket")]
        public async Task<IActionResult> CreateMarket(CommonViewModel model)
        {
            var data = await _MarketPrice.InsertUpdateMarket(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
        #region MarketPrice

        [HttpGet("GetAllMarketPrice")]
        public async Task<IActionResult> GetAllMarketPrice()
        {
            var data = await _MarketPrice.GetAllMarketPrice();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetMarketPriceById/{id}")]
        public async Task<IActionResult> GetMarketPriceById(int id = 0)
        {
            var data = await _MarketPrice.GetMarketPriceById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateMarketPrice")]
        public async Task<IActionResult> CreateMarketPrice(MarketPriceViewModel model)
        {
            var data = await _MarketPrice.InsertUpdateMarketPrice(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
    }
}
