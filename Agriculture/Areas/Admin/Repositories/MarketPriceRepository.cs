using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Agriculture.Areas.Admin.Repositories
{
    public class MarketPriceRepository : IMarketPrice
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<MarketPriceRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public MarketPriceRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<MarketPriceRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        #region Market
        public async Task<List<CommonViewModel>> GetAllMarket()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.Market.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new CommonViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameEng = x.NameEng,
                }).ToListAsync();
        }
        public async Task<CommonViewModel> GetMarketById(int id)
        {
            return await _context.Market.Where(x => x.Id == id)
                       .Select(x => new CommonViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           NameEng = x.NameEng,
                       }).FirstOrDefaultAsync() ?? new CommonViewModel();
        }
        public async Task<bool> InsertUpdateMarket(CommonViewModel model)
        {
            try
            {
                var data = _context.Market.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.NameEng = model.NameEng;

                    data.UpdatedBy = _userId;
                    data.UpdatedDate = DateTime.Now;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    int wardId = await _utility.GetWardNoForLogin_Role_User();

                    var newdata = new Market()
                    {
                        Name = model.Name,
                        NameEng = model.NameEng,

                        CreatedBy = _userId,
                        CreatedWardId = wardId,
                        CreatedDate = DateTime.Now,
                    };
                    await _context.Market.AddAsync(newdata);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion

        #region Market Price
        public async Task<List<MarketPriceViewModel>> GetAllMarketPrice()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.MarketPrice.Where(x => wardId == 0 || x.CreatedWardId == wardId)
                 .Select(x => new MarketPriceViewModel()
                 {
                     Id = x.Id,
                     Date = x.Date,
                     DateEng = x.DateEng,
                     MarketId = x.MarketId,
                     MarketName = x.Market.Name,
                 }).ToListAsync();
        }
        public async Task<MarketPriceViewModel> GetMarketPriceById(int id)
        {
            return await _context.MarketPrice.Where(x => x.Id == id)
                .Select(x => new MarketPriceViewModel()
                {
                    Id = x.Id,
                    Date = x.Date,
                    DateEng = x.DateEng,
                    MarketId = x.MarketId,
                    MarketPriceDetailsViewModelList = _context.MarketPriceDetails.Where(z => z.MarketPriceId == x.Id)
                    .Select(z => new MarketPriceDetailsViewModel()
                    {
                        Id = z.Id,
                        MarketPriceId = z.MarketPriceId,
                        AveragePrice = z.AveragePrice,
                        ProductName = z.ProductName,
                        RetailPrice = z.RetailPrice,
                        WholesalePrice = z.WholesalePrice
                    }).ToList() ?? new List<MarketPriceDetailsViewModel>(),
                }).FirstOrDefaultAsync() ?? new MarketPriceViewModel();
        }

        public async Task<bool> InsertUpdateMarketPrice(MarketPriceViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.MarketPrice.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.Date = model.Date;
                            data.DateEng = model.DateEng;
                            data.MarketId = model.MarketId;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.MarketPriceDetailsViewModelList != null)
                            {
                                foreach (var item in await _context.MarketPriceDetails.Where(x => x.MarketPriceId == model.Id).ToListAsync())
                                {
                                    if (!model.MarketPriceDetailsViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.MarketPriceDetails.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.MarketPriceDetailsViewModelList)
                                {
                                    var daata = await _context.MarketPriceDetails.FirstOrDefaultAsync(x => x.Id == item.Id);
                                    if (daata != null)
                                    {
                                        daata.ProductName = item.ProductName;
                                        daata.RetailPrice = item.RetailPrice;
                                        daata.WholesalePrice = item.WholesalePrice;
                                        daata.AveragePrice = item.AveragePrice;

                                        daata.UpdatedBy = _userId;
                                        daata.UpdatedDate = DateTime.Now;

                                        _context.Entry(daata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var adaata = new MarketPriceDetails()
                                        {
                                            MarketPriceId = model.Id,
                                            ProductName = item.ProductName,
                                            RetailPrice = item.RetailPrice,
                                            WholesalePrice = item.WholesalePrice,
                                            AveragePrice = item.AveragePrice,

                                            CreatedBy = _userId,
                                            CreatedDate = DateTime.Now,
                                        };
                                        await _context.MarketPriceDetails.AddAsync(adaata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                        }
                        else return false;
                    }
                    else
                    {
                        int wardId = await _utility.GetWardNoForLogin_Role_User();

                        var nedata = new MarketPrice()
                        {
                            Date = model.Date,
                            DateEng = model.DateEng,
                            MarketId = model.MarketId,

                            CreatedBy = _userId,
                        CreatedWardId = wardId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.MarketPrice.AddAsync(nedata);
                        await _context.SaveChangesAsync();

                        if (model.MarketPriceDetailsViewModelList != null)
                        {
                            foreach (var item in model.MarketPriceDetailsViewModelList)
                            {
                                var daata = new MarketPriceDetails()
                                {
                                    MarketPriceId = nedata.Id,
                                    ProductName = item.ProductName,
                                    RetailPrice = item.RetailPrice,
                                    WholesalePrice = item.WholesalePrice,
                                    AveragePrice = item.AveragePrice,

                                    CreatedBy = _userId,
                                    CreatedDate = DateTime.Now,
                                };
                                await _context.MarketPriceDetails.AddAsync(daata);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("InsertUpdateMarketPrice Repo create/update with multiple table (InsertUpdateMarketPriceDetails) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion
    }
}
