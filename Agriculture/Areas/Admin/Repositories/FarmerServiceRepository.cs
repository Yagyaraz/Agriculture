using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace Agriculture.Areas.Admin.Repositories
{
    public class FarmerServiceRepository : IFarmerService
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<FarmerServiceRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public FarmerServiceRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<FarmerServiceRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        #region Farmer Service

        public async Task<List<FarmerServiceViewModel>> GetAllFarmerService()
        {
            return await _context.AgriService.Where(x => !x.IsDeleted)
                .Select(x => new FarmerServiceViewModel()
                {
                    Id = x.Id,
                    AgriSectorId = x.AgriSectorId,
                    Name = x.Name,
                    NameEng = x.NameEng,
                    AgriSectorName = _context.AgriSector.Where(z => z.Id == x.AgriSectorId).Select(z => z.Name).FirstOrDefault(),
                }).ToListAsync();
        }
        public async Task<FarmerServiceViewModel> GetFarmerServiceById(int id)
        {
            return await _context.AgriService.Where(x => x.Id == id)
                  .Select(x => new FarmerServiceViewModel()
                  {
                      Id = x.Id,
                      AgriSectorId = x.AgriSectorId,
                      Name = x.Name,
                      NameEng = x.NameEng,
                  }).FirstOrDefaultAsync() ?? new FarmerServiceViewModel();
        }
        public async Task<bool> InsertUpdateFarmerService(FarmerServiceViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.AgriService.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.NameEng = model.NameEng;
                            data.Name = model.Name;
                            data.AgriSectorId = model.AgriSectorId;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        var newdata = new AgriService()
                        {
                            Name = model.Name,
                            AgriSectorId = model.AgriSectorId,
                            NameEng = model.NameEng,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.AgriService.AddAsync(newdata);
                        await _context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("FarmerService Repo create/update  Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

        #endregion

        #region FarmerServiceCard

        public async Task<List<FarmerServiceCardViewModel>> GetAllFarmerServiceCard()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            var data = await _context.FarmerServiceCard.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new FarmerServiceCardViewModel()
                {
                    Id = x.Id,
                    FiscalYearId = x.FiscalYearId,
                    ServiceDate = x.ServiceDate,
                    FarmerId = x.FarmerId,
                    FiscalYearName = x.FiscalYear.Name,
                    FarmerName = x.Farmer.FullName,
                    FarmerAddress = x.Farmer.District.DistrictNameNep + ", " + x.Farmer.Palika.PalikaNameNep + "- " + x.Farmer.WardNo,

                    ServiceName = _context.FarmerServiceCardDetail.Where(z => z.FarmerServiceCardId == x.Id).Select(z => z.AgriService.Name).FirstOrDefault(),
                    TypeName = _context.FarmerServiceCardDetail.Where(z => z.FarmerServiceCardId == x.Id).Select(z => z.AgriSector.Name).FirstOrDefault(),

                }).ToListAsync();
            return data;
        }

        public async Task<FarmerServiceCardViewModel> GetFarmerServiceCardById(int id)
        {
            return await _context.FarmerServiceCard.Where(x => x.Id == id)
                  .Select(x => new FarmerServiceCardViewModel()
                  {
                      Id = x.Id,
                      FiscalYearId = x.FiscalYearId,
                      ServiceDate = x.ServiceDate,
                      FarmerId = x.FarmerId,
                      FarmerServiceCardDetailList= _context.FarmerServiceCardDetail.Where(z => z.FarmerServiceCardId == x.Id)
                      .Select(z => new FarmerServiceCardDetailViewModel()
                      {
                          Id = z.Id,
                          FarmerServiceCardId = z.FarmerServiceCardId,
                          TypeId = z.TypeId,
                          ServiceId = z.ServiceId,
                          UnitId = z.UnitId,
                          Quantity = z.Quantity,
                          Detail = z.Detail,
                      }).ToList() ?? new List<FarmerServiceCardDetailViewModel>(),
                  }).FirstOrDefaultAsync() ?? new FarmerServiceCardViewModel();
        }

        public async Task<bool> InsertUpdateFarmerServiceCard(FarmerServiceCardViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var currentFiscalYearId = await _utility.GetCurrentFiscalYearId();
                    if (model.Id > 0)
                    {
                        var data = await _context.FarmerServiceCard.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.FiscalYearId = model.FiscalYearId;
                            data.ServiceDate = model.ServiceDate;
                            data.FarmerId = model.FarmerId;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.FarmerServiceCardDetailList!= null)
                            {
                                foreach (var item in await _context.FarmerServiceCardDetail.Where(x => x.FarmerServiceCardId == model.Id).ToListAsync())
                                {
                                    if (!model.FarmerServiceCardDetailList.Any(x => x.Id == item.Id))
                                    {
                                        _context.FarmerServiceCardDetail.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.FarmerServiceCardDetailList)
                                {
                                    var adata = await _context.FarmerServiceCardDetail.Where(x => x.Id == item.Id).FirstOrDefaultAsync();
                                    if (adata != null)
                                    {
                                        adata.TypeId = item.TypeId;
                                        adata.ServiceId = item.ServiceId;
                                        adata.UnitId = item.UnitId;
                                       adata.Quantity = item.Quantity;
                                        adata.Detail = item.Detail;

                                        _context.Entry(adata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var daat = new FarmerServiceCardDetail()
                                        {
                                            FarmerServiceCardId = model.Id,
                                            TypeId = item.TypeId,
                                            ServiceId = item.ServiceId,
                                            UnitId = item.UnitId,
                                            Quantity = item.Quantity,
                                            Detail = item.Detail,
                                        };
                                        await _context.FarmerServiceCardDetail.AddAsync(daat);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        int wardId = await _utility.GetWardNoForLogin_Role_User();
                        var newdata = new FarmerServiceCard()
                        {
                            FiscalYearId = currentFiscalYearId,
                            ServiceDate = model.ServiceDate,
                            FarmerId = model.FarmerId,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                            CreatedWardId = wardId,

                        };
                        await _context.FarmerServiceCard.AddAsync(newdata);
                        await _context.SaveChangesAsync();

                        if (model.FarmerServiceCardDetailList != null)
                        {
                            foreach (var item in model.FarmerServiceCardDetailList)
                            {
                                var daat = new FarmerServiceCardDetail()
                                {
                                    FarmerServiceCardId = newdata.Id,
                                    TypeId = item.TypeId,
                                    ServiceId = item.ServiceId,
                                    UnitId = item.UnitId,
                                    Quantity = item.Quantity,
                                    Detail = item.Detail,
                                };
                                await _context.FarmerServiceCardDetail.AddAsync(daat);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("FarmerServiceCard Repo create/update with multiple table (FarmerServiceCardDetail) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion
    }
}
