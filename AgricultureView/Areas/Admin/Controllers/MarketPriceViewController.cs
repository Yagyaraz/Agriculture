using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MarketPriceViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public MarketPriceViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        #region Market
        public async Task<IActionResult> Market()
        {
            var response = await _globalVeriable.GetMethod("Admin/MarketPrice/GetAllMarket");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<CommonViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<CommonViewModel>());
        }
        public async Task<IActionResult> MarketCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/MarketPrice/GetMarketById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<CommonViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new CommonViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> MarketCreate(CommonViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/MarketPrice/CreateMarket", model);
            if (response.Status)
            {
                return RedirectToAction("Market");
            }
            return View(model);
        }
        #endregion
        #region MarketPrice
        public async Task<IActionResult> MarketPrice()
        {
            var response = await _globalVeriable.GetMethod("Admin/MarketPrice/GetAllMarketPrice");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<MarketPriceViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<MarketPriceViewModel>());
        }
        public async Task<IActionResult> MarketPriceCreate(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/MarketPrice/GetMarketPriceById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<MarketPriceViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new MarketPriceViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> MarketPriceCreate(MarketPriceViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/MarketPrice/CreateMarketPrice", model);
            if (response.Status)
            {
                return RedirectToAction("MarketPrice");
            }
            return View(model);
        }
        public IActionResult MarketPriceDetail() => PartialView("_MarketPriceDetail", new MarketPriceDetailsViewModel());
        #endregion
    }
}
