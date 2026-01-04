using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Security.Claims;

namespace Agriculture.Areas.Admin.Repositories
{
    public class AgriCalendarRepository : IAgriCalendar
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<AgriCalendarRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public AgriCalendarRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<AgriCalendarRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        #region AgriCalendarType
        public async Task<List<AgriCalendarTypeViewModel>> GetAllAgriCalendarType()
        {
            return await _context.AgriCalendarType.Where(x=>!x.IsDeleted)
                .Select(x => new AgriCalendarTypeViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameEng = x.NameEng,
                }).ToListAsync();
        }
        public async Task<AgriCalendarTypeViewModel> GetAgriCalendarTypeById(int id)
        {
            return await _context.AgriCalendarType.Where(x => x.Id == id)
                       .Select(x => new AgriCalendarTypeViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           NameEng = x.NameEng,
                       }).FirstOrDefaultAsync() ?? new AgriCalendarTypeViewModel();
        }
        public async Task<bool> InsertUpdateAgriCalendarType(AgriCalendarTypeViewModel model)
        {
            try
            {
                var data = _context.AgriCalendarType.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.NameEng = model.NameEng;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    var newdata = new AgriCalendarType()
                    {
                        Name = model.Name,
                        NameEng = model.NameEng,
                    };
                    await _context.AgriCalendarType.AddAsync(newdata);
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
        #region AgriCalendarCategory
        public async Task<List<AgriCalendarCategoryViewModel>> GetAllAgriCalendarCategory()
        {
            return await _context.AgriCalendarCategory.Where(x => !x.IsDeleted)
                .Select(x => new AgriCalendarCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameEng = x.NameEng,
                    AgriCalendarTypeId = x.AgriCalendarTypeId,
                    AgriCalendarType = x.AgriCalendarType.Name,
                }).ToListAsync();
        }
        public async Task<AgriCalendarCategoryViewModel> GetAgriCalendarCategoryById(int id)
        {
            return await _context.AgriCalendarCategory.Where(x => x.Id == id)
                       .Select(x => new AgriCalendarCategoryViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           NameEng = x.NameEng,
                           AgriCalendarTypeId = x.AgriCalendarTypeId
                       }).FirstOrDefaultAsync() ?? new AgriCalendarCategoryViewModel();
        }
        public async Task<bool> InsertUpdateAgriCalendarCategory(AgriCalendarCategoryViewModel model)
        {
            try
            {
                var data = _context.AgriCalendarCategory.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.NameEng = model.NameEng;
                    data.AgriCalendarTypeId = model.AgriCalendarTypeId;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    var newdata = new AgriCalendarCategory()
                    {
                        Name = model.Name,
                        NameEng = model.NameEng,
                        AgriCalendarTypeId= model.AgriCalendarTypeId
                    };
                    await _context.AgriCalendarCategory.AddAsync(newdata);
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
        #region AgriCalendarProduct
        public async Task<List<AgriCalendarProductViewModel>> GetAllAgriCalendarProduct()
        {
            return await _context.AgriCalendarProduct.Where(x => !x.IsDeleted)
                .Select(x => new AgriCalendarProductViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    NameEng = x.NameEng,
                    AgriCalendarCategoryId = x.AgriCalendarCategoryId,
                    AgriCalendarTypeId = x.AgriCalendarTypeId,
                    AgriCalendarCategory = x.AgriCalendarCategory.Name,
                    AgriCalendarType = x.AgriCalendarType.Name,
                }).ToListAsync();
        }
        public async Task<AgriCalendarProductViewModel> GetAgriCalendarProductById(int id)
        {
            return await _context.AgriCalendarProduct.Where(x => x.Id == id)
                       .Select(x => new AgriCalendarProductViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           NameEng = x.NameEng,
                           AgriCalendarCategoryId = x.AgriCalendarCategoryId,
                           AgriCalendarTypeId= x.AgriCalendarTypeId,
                       }).FirstOrDefaultAsync() ?? new AgriCalendarProductViewModel();
        }
        public async Task<bool> InsertUpdateAgriCalendarProduct(AgriCalendarProductViewModel model)
        {
            try
            {
                var data = _context.AgriCalendarProduct.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.NameEng = model.NameEng;
                    data.AgriCalendarCategoryId = model.AgriCalendarCategoryId;
                    data.AgriCalendarTypeId = model.AgriCalendarTypeId;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    var newdata = new AgriCalendarProduct()
                    {
                        Name = model.Name,
                        NameEng = model.NameEng,
                        AgriCalendarCategoryId= model.AgriCalendarCategoryId,
                        AgriCalendarTypeId = model.AgriCalendarTypeId,
                    };
                    await _context.AgriCalendarProduct.AddAsync(newdata);
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
        #region AgriCalendar
        public async Task<List<AgriCalendarViewModel>> GetAllAgriCalendar()
        {
            return await _context.AgriCalendar
                .Select(x => new AgriCalendarViewModel()
                {
                    Id = x.Id,
                    TypeId = x.TypeId,
                    CategoryId = x.CategoryId,
                    ProductId = x.ProductId,
                    Variety = x.Variety,

                    TypeName = x.AgriCalendarType.Name,
                    CategoryName = x.AgriCalendarCategory.Name,
                    ProductName = x.AgriCalendarProduct.Name,
                }).ToListAsync();
        }
        public async Task<AgriCalendarViewModel> GetAgriCalendarById(int id)
        {
            return await _context.AgriCalendar.Where(x => x.Id == id)
                       .Select(x => new AgriCalendarViewModel()
                       {
                           Id = x.Id,
                           TypeId = x.TypeId,
                           CategoryId = x.CategoryId,
                           ProductId = x.ProductId,
                           Variety = x.Variety,
                           AgriCalendarDetailViewModelList = _context.AgriCalendarDetail.Where(z => z.AgriCalendarId == x.Id)
                           .Select(z =>new AgriCalendarDetailViewModel()
                           {
                               Id = z.Id,
                               AgriCalendarId = z.AgriCalendarId,
                               EcologicalAreaId = z.EcologicalAreaId,
                               ElevationFrom = z.ElevationFrom,
                               ElevationTo = z.ElevationTo,
                               SowingStartMonthId = z.SowingStartMonthId,
                               SowingEndMonthId = z.SowingEndMonthId,
                               SowingEndWeekId = z.SowingEndWeekId,
                               SowingStartWeekId = z.SowingStartWeekId,
                               HarvestStartMonthId = z.HarvestStartMonthId,
                               HarvestEndMonthId = z.HarvestEndMonthId,
                               HarvestStartWeekId = z.HarvestStartWeekId,
                               HarvestEndWeekId = z.HarvestEndWeekId,
                           }).ToList() ?? new List<AgriCalendarDetailViewModel>(),
                       }).FirstOrDefaultAsync() ?? new AgriCalendarViewModel();
        }
        public async Task<bool> InsertUpdateAgriCalendar(AgriCalendarViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = _context.AgriCalendar.FirstOrDefault(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.TypeId = model.TypeId;
                            data.CategoryId = model.CategoryId;
                            data.ProductId = model.ProductId;
                            data.Variety = model.Variety;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.AgriCalendarDetailViewModelList != null)
                            {
                                foreach (var item in await _context.AgriCalendarDetail.Where(x => x.AgriCalendarId == model.Id).ToListAsync())
                                {
                                    if (!model.AgriCalendarDetailViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.AgriCalendarDetail.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.AgriCalendarDetailViewModelList)
                                {
                                    var daata = await _context.AgriCalendarDetail.Where(x => x.Id == item.Id).FirstOrDefaultAsync();
                                    if (daata != null)
                                    {
                                        daata.EcologicalAreaId = item.EcologicalAreaId;
                                        daata.ElevationFrom = item.ElevationFrom;
                                        daata.ElevationTo = item.ElevationTo;
                                        daata.SowingStartMonthId = item.SowingStartMonthId;
                                        daata.SowingEndMonthId = item.SowingEndMonthId;
                                        daata.SowingEndWeekId = item.SowingEndWeekId;
                                        daata.SowingStartWeekId = item.SowingStartWeekId;
                                        daata.HarvestStartMonthId = item.HarvestStartMonthId;
                                        daata.HarvestEndMonthId = item.HarvestEndMonthId;
                                        daata.HarvestStartWeekId = item.HarvestStartWeekId;
                                        daata.HarvestEndWeekId = item.HarvestEndWeekId;

                                        data.UpdatedBy = _userId;
                                        data.UpdatedDate = DateTime.Now;

                                        _context.Entry(daata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var adata = new AgriCalendarDetail()
                                        {
                                            AgriCalendarId = model.Id,
                                            EcologicalAreaId = item.EcologicalAreaId,
                                            ElevationFrom = item.ElevationFrom,
                                            ElevationTo = item.ElevationTo,
                                            SowingStartMonthId = item.SowingStartMonthId,
                                            SowingEndMonthId = item.SowingEndMonthId,
                                            SowingEndWeekId = item.SowingEndWeekId,
                                            SowingStartWeekId = item.SowingStartWeekId,
                                            HarvestStartMonthId = item.HarvestStartMonthId,
                                            HarvestEndMonthId = item.HarvestEndMonthId,
                                            HarvestStartWeekId = item.HarvestStartWeekId,
                                            HarvestEndWeekId = item.HarvestEndWeekId,

                                            CreatedBy = _userId,
                                            CreatedDate = DateTime.Now,
                                        };
                                        await _context.AgriCalendarDetail.AddAsync(adata);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                            }
                        }
                        else return false;
                    }
                    else
                    {
                        var newdata = new AgriCalendar()
                        {
                            TypeId = model.TypeId,
                            CategoryId = model.CategoryId,
                            ProductId = model.ProductId,
                            Variety = model.Variety,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.AgriCalendar.AddAsync(newdata);
                        await _context.SaveChangesAsync();

                        if (model.AgriCalendarDetailViewModelList != null)
                        {
                            foreach (var item in model.AgriCalendarDetailViewModelList)
                            {
                                var data = new AgriCalendarDetail()
                                {
                                    AgriCalendarId = newdata.Id,
                                    EcologicalAreaId = item.EcologicalAreaId,
                                    ElevationFrom = item.ElevationFrom,
                                    ElevationTo = item.ElevationTo,
                                    SowingStartMonthId = item.SowingStartMonthId,
                                    SowingEndMonthId = item.SowingEndMonthId,
                                    SowingEndWeekId = item.SowingEndWeekId,
                                    SowingStartWeekId = item.SowingStartWeekId,
                                    HarvestStartMonthId = item.HarvestStartMonthId,
                                    HarvestEndMonthId = item.HarvestEndMonthId,
                                    HarvestStartWeekId = item.HarvestStartWeekId,
                                    HarvestEndWeekId = item.HarvestEndWeekId,

                                    CreatedBy = _userId,
                                    CreatedDate = DateTime.Now,
                                };
                                await _context.AgriCalendarDetail.AddAsync(data);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("AgriCalendar Repo create/update with multiple table (AgriCalendarDetail) Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion
    }
}
