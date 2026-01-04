using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Xml.Linq;

namespace Agriculture.Areas.Admin.Repositories
{
    public class AgricultureFarmerGroupRepository : IAgricultureFarmerGroup
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<AgricultureFarmerGroupRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public AgricultureFarmerGroupRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<AgricultureFarmerGroupRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        public async Task<List<AgricultureFarmerGroupViewModel>> GetAllAgricultureFarmerGroup()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.AgricultureFarmerGroup.Where(x => wardId == 0 || x.CreatedWardId == wardId).Where(x => !x.IsDeleted)
                .Select(x => new AgricultureFarmerGroupViewModel()
                {
                    Id = x.Id,
                    AgriGroupTypeId = x.AgriGroupTypeId,
                    FirmDartaNo = x.FirmDartaNo,
                    FirmEstdDate = x.FirmEstdDate,
                    FirmHitKoshAmt = x.FirmHitKoshAmt,
                    FirmName = x.FirmName + " - " + x.FirmNameEng,
                    FirmNameEng = x.FirmNameEng,
                    FirmPalikaName = x.FirmPalikaName + " - " + "वार्ड नम्बर - " + x.FirmWardNo + " - " + x.FirmTolName,
                    FirmPanNo = x.FirmPanNo,
                    FirmRegDate = x.FirmRegDate,
                    FirmTolName = x.FirmTolName,
                    FirmWardNo = x.FirmWardNo,
                    KaryalayeName = x.KaryalayeName,
                    SadsyeFemaleCount = x.SadsyeFemaleCount,
                    SadsyeMaleCount = x.SadsyeMaleCount,
                    SadsyeOtherCount = x.SadsyeOtherCount,
                    SamuhaAim = x.SamuhaAim,
                    SamuhaDetails = x.SamuhaDetails,
                    SamuhaWardNo = x.SamuhaWardNo,
                    AgriGroupType = x.AgriGroupType.Name,
                }).ToListAsync();
        }

        public async Task<AgricultureFarmerGroupViewModel> GetAgricultureFarmerGroupById(int id)
        {
            return await _context.AgricultureFarmerGroup.Where(x => x.Id == id)
                  .Select(x => new AgricultureFarmerGroupViewModel()
                  {
                      Id = x.Id,
                      AgriGroupTypeId = x.AgriGroupTypeId,
                      FirmDartaNo = x.FirmDartaNo,
                      FirmEstdDate = x.FirmEstdDate,
                      FirmHitKoshAmt = x.FirmHitKoshAmt,
                      FirmName = x.FirmName,
                      FirmNameEng = x.FirmNameEng,
                      FirmPalikaName = x.FirmPalikaName,
                      FirmPanNo = x.FirmPanNo,
                      FirmRegDate = x.FirmRegDate,
                      FirmTolName = x.FirmTolName,
                      FirmWardNo = x.FirmWardNo,
                      KaryalayeName = x.KaryalayeName,
                      SadsyeFemaleCount = x.SadsyeFemaleCount,
                      SadsyeMaleCount = x.SadsyeMaleCount,
                      SadsyeOtherCount = x.SadsyeOtherCount,
                      SamuhaAim = x.SamuhaAim,
                      SamuhaDetails = x.SamuhaDetails,
                      SamuhaWardNo = x.SamuhaWardNo,
                      OfficialsDetailViewModelList = _context.OfficialsDetail.Where(z => z.AgricultureFarmerGroupId == x.Id)
                      .Select(z => new OfficialsDetailViewModel()
                      {
                          Id = z.Id,
                          AgricultureFarmerGroupId = z.AgricultureFarmerGroupId,
                          Age = z.Age,
                          Area = z.Area,
                          FullName = z.FullName,
                          LiterateLevelId = z.LiterateLevelId,
                          PostId = z.PostId,
                      }).ToList() ?? new List<OfficialsDetailViewModel>(),
                  }).FirstOrDefaultAsync() ?? new AgricultureFarmerGroupViewModel();
        }

        public async Task<bool> InsertUpdateAgricultureFarmerGroup(AgricultureFarmerGroupViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.AgricultureFarmerGroup.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.AgriGroupTypeId = model.AgriGroupTypeId;
                            data.FirmDartaNo = model.FirmDartaNo;
                            data.FirmEstdDate = model.FirmEstdDate;
                            data.FirmHitKoshAmt = model.FirmHitKoshAmt;
                            data.FirmName = model.FirmName;
                            data.FirmNameEng = model.FirmNameEng;
                            data.FirmPalikaName = model.FirmPalikaName;
                            data.FirmPanNo = model.FirmPanNo;
                            data.FirmRegDate = model.FirmRegDate;
                            data.FirmTolName = model.FirmTolName;
                            data.FirmWardNo = model.FirmWardNo;
                            data.KaryalayeName = model.KaryalayeName;
                            data.SadsyeFemaleCount = model.SadsyeFemaleCount;
                            data.SadsyeMaleCount = model.SadsyeMaleCount;
                            data.SadsyeOtherCount = model.SadsyeOtherCount;
                            data.SamuhaAim = model.SamuhaAim;
                            data.SamuhaDetails = model.SamuhaDetails;
                            data.SamuhaWardNo = model.SamuhaWardNo;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.OfficialsDetailViewModelList != null)
                            {
                                foreach (var item in await _context.OfficialsDetail.Where(x => x.AgricultureFarmerGroupId == model.Id).ToListAsync())
                                {
                                    if (!model.OfficialsDetailViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.OfficialsDetail.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.OfficialsDetailViewModelList)
                                {
                                    var adata = await _context.OfficialsDetail.Where(x => x.Id == item.Id).FirstOrDefaultAsync();
                                    if (adata != null)
                                    {
                                        adata.Age = item.Age;
                                        adata.Area = item.Area;
                                        adata.FullName = item.FullName;
                                        adata.LiterateLevelId = item.LiterateLevelId;
                                        adata.PostId = item.PostId;

                                        _context.Entry(adata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var daat = new OfficialsDetail()
                                        {
                                            AgricultureFarmerGroupId = model.Id,
                                            Age = item.Age,
                                            Area = item.Area,
                                            FullName = item.FullName,
                                            LiterateLevelId = item.LiterateLevelId,
                                            PostId = item.PostId,
                                        };
                                        await _context.OfficialsDetail.AddAsync(daat);
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
                        var newdata = new AgricultureFarmerGroup()
                        {
                            AgriGroupTypeId = model.AgriGroupTypeId,
                            FirmDartaNo = model.FirmDartaNo,
                            FirmEstdDate = model.FirmEstdDate,
                            FirmHitKoshAmt = model.FirmHitKoshAmt,
                            FirmName = model.FirmName,
                            FirmNameEng = model.FirmNameEng,
                            FirmPalikaName = model.FirmPalikaName,
                            FirmPanNo = model.FirmPanNo,
                            FirmRegDate = model.FirmRegDate,
                            FirmTolName = model.FirmTolName,
                            FirmWardNo = model.FirmWardNo,
                            KaryalayeName = model.KaryalayeName,
                            SadsyeFemaleCount = model.SadsyeFemaleCount,
                            SadsyeMaleCount = model.SadsyeMaleCount,
                            SadsyeOtherCount = model.SadsyeOtherCount,
                            SamuhaAim = model.SamuhaAim,
                            SamuhaDetails = model.SamuhaDetails,
                            SamuhaWardNo = model.SamuhaWardNo,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                            CreatedWardId = wardId,

                        };
                        await _context.AgricultureFarmerGroup.AddAsync(newdata);
                        await _context.SaveChangesAsync();

                        if (model.OfficialsDetailViewModelList != null)
                        {
                            foreach (var item in model.OfficialsDetailViewModelList)
                            {
                                var daat = new OfficialsDetail()
                                {
                                    AgricultureFarmerGroupId = newdata.Id,
                                    Age = item.Age,
                                    Area = item.Area,
                                    FullName = item.FullName,
                                    LiterateLevelId = item.LiterateLevelId,
                                    PostId = item.PostId,
                                };
                                await _context.OfficialsDetail.AddAsync(daat);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("AgricultureFarmerGroup Repo create/update with multiple table (OfficialsDetail) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
