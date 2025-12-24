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
    public class SubsidyRepository : ISubsidy
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<SubsidyRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public SubsidyRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<SubsidyRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        #region Category
        public async Task<List<CategoryViewModel>> GetAllCategory()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.Category.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new CategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                }).ToListAsync();
        }
        public async Task<CategoryViewModel> GetCategoryById(int id)
        {
            return await _context.Category.Where(x => x.Id == id)
               .Select(x => new CategoryViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
               }).FirstOrDefaultAsync() ?? new CategoryViewModel();
        }
        public async Task<bool> InsertUpdateCategory(CategoryViewModel model)
        {
            try
            {
                var data = await _context.Category.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;

                    data.UpdatedBy = _userId;
                    data.UpdatedDate = DateTime.Now;

                    _context.Entry(data).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    int wardId = await _utility.GetWardNoForLogin_Role_User();

                    var daata = new Category()
                    {
                        Name = model.Name,

                        CreatedWardId = wardId,
                        CreatedBy = _userId,
                        CreatedDate = DateTime.Now,
                    };
                    await _context.Category.AddAsync(daata);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Category Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                return false;
            }
        }
        #endregion
        #region SubCategory
        public async Task<List<SubCategoryViewModel>> GetAllSubCategory()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.SubCategory.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new SubCategoryViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryId = x.CategoryId,
                    CategoryUnitId = x.CategoryUnitId,

                    CategoryName = x.Category.Name,
                    CategoryUnit = x.MeasuringUnit.Name,
                }).ToListAsync();
        }
        public async Task<SubCategoryViewModel> GetSubCategoryById(int id)
        {
            return await _context.SubCategory.Where(x => x.Id == id)
               .Select(x => new SubCategoryViewModel()
               {
                   Id = x.Id,
                   Name = x.Name,
                   CategoryUnitId = x.CategoryUnitId,
                   CategoryId = x.CategoryId
               }).FirstOrDefaultAsync() ?? new SubCategoryViewModel();
        }
        public async Task<bool> InsertUpdateSubCategory(SubCategoryViewModel model)
        {
            try
            {
                var data = await _context.SubCategory.FirstOrDefaultAsync(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.CategoryId = model.CategoryId;
                    data.CategoryUnitId = model.CategoryUnitId;

                    data.UpdatedBy = _userId;
                    data.UpdatedDate = DateTime.Now;

                    _context.Entry(data).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    int wardId = await _utility.GetWardNoForLogin_Role_User();

                    var daata = new SubCategory()
                    {
                        Name = model.Name,
                        CategoryUnitId = model.CategoryUnitId,
                        CategoryId = model.CategoryId,

                        CreatedBy = _userId,
                        CreatedWardId = wardId,
                        CreatedDate = DateTime.Now,
                    };
                    await _context.SubCategory.AddAsync(daata);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("SubCategory Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                return false;
            }
        }
        #endregion
        #region Subsidy
        public async Task<List<SubsidyViewModel>> GetAllSubsidy()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.Subsidy.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new SubsidyViewModel()
                {
                    Id = x.Id,
                    EndDate = x.EndDate,
                    EndDateEng = x.EndDateEng,
                    FiscalYearId = x.FiscalYearId,
                    ProgramId = x.ProgramId,
                    ProjectId = x.ProjectId,
                    StartDate = x.StartDate,
                    StartDateEng = x.StartDateEng,
                    ProgramName = x.AgricultureProgram.Title,
                    ProjectName = x.AgricultureProject.ProjectName,
                }).ToListAsync();
        }
        public async Task<List<SubsidyViewModel>> GetAllSubsidyForUser()
        {
            int farmerId = await _utility.GetWardNoForLogin_Role_FarmerId();

            var data = await (from sr in _context.SaveRequestedSubsidy
                              join s in _context.Subsidy on sr.SubsidyId equals s.Id
                              where sr.FarmerId == farmerId
                              group sr by new
                              {
                                  s.Id,
                                  s.EndDate,
                                  s.EndDateEng,
                                  s.FiscalYearId,
                                  s.ProgramId,
                                  s.ProjectId,
                                  s.StartDate,
                                  s.StartDateEng,
                                  s.AgricultureProgram.Title,
                                  s.AgricultureProject.ProjectName
                              } into g
                              select new SubsidyViewModel()
                              {
                                  EndDate = g.Key.EndDate,
                                  EndDateEng = g.Key.EndDateEng,
                                  FiscalYearId = g.Key.FiscalYearId,
                                  ProgramId = g.Key.ProgramId,
                                  ProjectId = g.Key.ProjectId,
                                  StartDate = g.Key.StartDate,
                                  StartDateEng = g.Key.StartDateEng,
                                  ProgramName = g.Key.Title,
                                  ProjectName = g.Key.ProjectName,
                                  AcquiredQty = g.Sum(x => x.TotalRequired) // Summing the TotalRequired values
                              }).ToListAsync();
            return data;
        }
        public async Task<SubsidyPopupViewModel> GetSubsidyByIdForPopUp(int id)
        {
            return await _context.Subsidy.Where(x => x.Id == id)
               .Select(x => new SubsidyPopupViewModel()
               {
                   Id = x.Id,
                   EndDate = x.EndDate,
                   EndDateEng = x.EndDateEng,
                   FiscalYearId = x.FiscalYearId,
                   ProgramId = x.ProgramId,
                   ProjectId = x.ProjectId,
                   StartDate = x.StartDate,
                   StartDateEng = x.StartDateEng,
                   SubsidyDetailPopupViewModelList = _context.SubsidyDetail.Where(z => z.SubsidyId == x.Id)
                   .Select(z => new SubsidyDetailPopupViewModel()
                   {
                       Id = z.Id,
                       SubsidyId = z.SubsidyId,
                       SubCategoryName = z.SubCategory.Name,
                       CategoryId = z.CategoryId,
                       Quantity = z.Quantity,
                       RemainingQty = _context.SaveRequestedSubsidy.Where(x => x.SubsidyId == z.SubsidyId).Select(x => x.TotalRequired).Sum(),
                       SubCategoryId = z.SubCategoryId,
                   }).ToList() ?? new List<SubsidyDetailPopupViewModel>(),
               }).FirstOrDefaultAsync() ?? new SubsidyPopupViewModel();
        }
        public async Task<SubsidyViewModel> GetSubsidyById(int id)
        {
            return await _context.Subsidy.Where(x => x.Id == id)
               .Select(x => new SubsidyViewModel()
               {
                   Id = x.Id,
                   EndDate = x.EndDate,
                   EndDateEng = x.EndDateEng,
                   FiscalYearId = x.FiscalYearId,
                   ProgramId = x.ProgramId,
                   ProjectId = x.ProjectId,
                   StartDate = x.StartDate,
                   StartDateEng = x.StartDateEng,
                   SubsidyDetailViewModelList = _context.SubsidyDetail.Where(z => z.SubsidyId == x.Id)
                   .Select(z => new SubsidyDetailViewModel()
                   {
                       Id = z.Id,
                       SubsidyId = z.SubsidyId,
                       CategoryId = z.CategoryId,
                       Quantity = z.Quantity,
                       SubCategoryId = z.SubCategoryId,
                   }).ToList() ?? new List<SubsidyDetailViewModel>(),
               }).FirstOrDefaultAsync() ?? new SubsidyViewModel();
        }
        public async Task<bool> InsertUpdateSubsidy(SubsidyViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.Subsidy.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.EndDate = model.EndDate;
                            data.EndDateEng = model.EndDateEng;
                            data.FiscalYearId = model.FiscalYearId;
                            data.ProgramId = model.ProgramId;
                            data.ProjectId = model.ProjectId;
                            data.StartDate = model.StartDate;
                            data.StartDateEng = model.StartDateEng;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.SubsidyDetailViewModelList != null)
                            {
                                foreach (var item in await _context.SubsidyDetail.Where(x => x.SubsidyId == model.Id).ToListAsync())
                                {
                                    if (!model.SubsidyDetailViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.SubsidyDetail.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.SubsidyDetailViewModelList)
                                {
                                    var adata = _context.SubsidyDetail.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (adata != null)
                                    {
                                        adata.CategoryId = item.CategoryId;
                                        adata.Quantity = item.Quantity;
                                        adata.SubCategoryId = item.SubCategoryId;

                                        adata.UpdatedBy = _userId;
                                        adata.UpdatedDate = DateTime.Now;

                                        _context.Entry(adata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var dataa = new SubsidyDetail()
                                        {
                                            SubsidyId = model.Id,
                                            CategoryId = item.CategoryId,
                                            Quantity = item.Quantity,
                                            SubCategoryId = item.SubCategoryId,

                                            CreatedBy = _userId,
                                            CreatedDate = DateTime.Now,
                                        };
                                        await _context.SubsidyDetail.AddAsync(dataa);
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

                        var daata = new Subsidy()
                        {
                            EndDate = model.EndDate,
                            EndDateEng = model.EndDateEng,
                            FiscalYearId = model.FiscalYearId,
                            ProgramId = model.ProgramId,
                            ProjectId = model.ProjectId,
                            StartDate = model.StartDate,
                            StartDateEng = model.StartDateEng,

                            CreatedWardId = wardId,
                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.Subsidy.AddAsync(daata);
                        await _context.SaveChangesAsync();

                        if (model.SubsidyDetailViewModelList != null)
                        {
                            foreach (var item in model.SubsidyDetailViewModelList)
                            {
                                var data = new SubsidyDetail()
                                {
                                    SubsidyId = daata.Id,
                                    CategoryId = item.CategoryId,
                                    Quantity = item.Quantity,
                                    SubCategoryId = item.SubCategoryId,

                                    CreatedBy = _userId,
                                    CreatedDate = DateTime.Now,
                                };
                                await _context.SubsidyDetail.AddAsync(data);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Subsidy Repo along with multiple repo(subsidarydetails) create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }

        public async Task<bool> SaveRequestedSubsidy(List<SaveRequestedSubsidyViewModel> model)
        {
            try
            {
                if (model.Count > 0)
                {

                    foreach (var item in model)
                    {
                        int wardId = await _utility.GetWardNoForLogin_Role_User();
                        var data = new SaveRequestedSubsidy()
                        {
                            SubsidyDetailId = item.Id,
                            Quantity = item.Quantity,
                            SubsidyId = item.SubsidyId,
                            TotalRequired = item.TotalRequired,
                            FarmerId = item.FarmerId,

                            CreatedWardId = wardId,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.SaveRequestedSubsidy.AddAsync(data);
                        await _context.SaveChangesAsync();
                    }
                    return true;
                }
                else return false;
            }
            catch (Exception ex)
            {
                _logger.LogInformation("Subsidy Repo along with multiple repo(SaveRequestedSubsidy) create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                return false;
            }
        }
        #endregion
        #region OtherSubsidy
        public async Task<List<OtherSubsidyViewModel>> GetAllOtherSubsidy()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.OtherSubsidy.Where(x =>
            !x.IsDeleted && (wardId == 0 || x.CreatedWardId == wardId))
                .Select(x => new OtherSubsidyViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    EndDate = x.EndDate,
                    EndDateEng = x.EndDateEng,
                    StartDate = x.StartDate,
                    StartDateEng = x.StartDateEng,
                    Description = x.Description,
                    ProvidedBy = x.ProvidedBy,
                }).ToListAsync();
        }
        public async Task<OtherSubsidyViewModel> GetOtherSubsidyById(int id)
        {
            return await _context.OtherSubsidy.Where(x => x.Id == id)
               .Select(x => new OtherSubsidyViewModel()
               {
                   Id = x.Id,
                   Title = x.Title,
                   EndDate = x.EndDate,
                   EndDateEng = x.EndDateEng,
                   StartDate = x.StartDate,
                   StartDateEng = x.StartDateEng,
                   Description = x.Description,
                   ProvidedBy = x.ProvidedBy,
                   OtherSubsidyQnsViewModelList = _context.OtherSubsidyQns.Where(z => z.OtherSubsidyId == x.Id)
                   .Select(z => new OtherSubsidyQnsViewModel()
                   {
                       Id = z.Id,
                       OtherSubsidyId = z.OtherSubsidyId,
                       Qns = z.Qns,
                   }).ToList() ?? new List<OtherSubsidyQnsViewModel>(),
               }).FirstOrDefaultAsync() ?? new OtherSubsidyViewModel();
        }
        public async Task<bool> InsertUpdateOtherSubsidy(OtherSubsidyViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    if (model.Id > 0)
                    {
                        var data = await _context.OtherSubsidy.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (data != null)
                        {
                            data.EndDate = model.EndDate;
                            data.EndDateEng = model.EndDateEng;
                            data.StartDate = model.StartDate;
                            data.StartDateEng = model.StartDateEng;
                            data.Title = model.Title;
                            data.Description = model.Description;
                            data.ProvidedBy = model.ProvidedBy;

                            data.UpdatedBy = _userId;
                            data.UpdatedDate = DateTime.Now;

                            _context.Entry(data).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                            if (model.OtherSubsidyQnsViewModelList != null)
                            {
                                foreach (var item in await _context.OtherSubsidyQns.Where(x => x.OtherSubsidyId == model.Id).ToListAsync())
                                {
                                    if (!model.OtherSubsidyQnsViewModelList.Any(x => x.Id == item.Id))
                                    {
                                        _context.OtherSubsidyQns.Remove(item);
                                        await _context.SaveChangesAsync();
                                    }
                                }
                                foreach (var item in model.OtherSubsidyQnsViewModelList)
                                {
                                    var adata = _context.OtherSubsidyQns.Where(x => x.Id == item.Id).FirstOrDefault();
                                    if (adata != null)
                                    {
                                        adata.Qns = item.Qns;

                                        _context.Entry(adata).State = EntityState.Modified;
                                        await _context.SaveChangesAsync();
                                    }
                                    else
                                    {
                                        var dataa = new OtherSubsidyQns()
                                        {
                                            OtherSubsidyId = model.Id,
                                            Qns = item.Qns,
                                        };
                                        await _context.OtherSubsidyQns.AddAsync(dataa);
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

                        var daata = new OtherSubsidy()
                        {
                            EndDate = model.EndDate,
                            EndDateEng = model.EndDateEng,
                            StartDate = model.StartDate,
                            StartDateEng = model.StartDateEng,
                            Title = model.Title,
                            Description = model.Description,
                            ProvidedBy = model.ProvidedBy,

                            CreatedWardId = wardId,
                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.OtherSubsidy.AddAsync(daata);
                        await _context.SaveChangesAsync();

                        if (model.OtherSubsidyQnsViewModelList != null)
                        {
                            foreach (var item in model.OtherSubsidyQnsViewModelList)
                            {
                                var data = new OtherSubsidyQns()
                                {
                                    OtherSubsidyId = daata.Id,
                                    Qns = item.Qns,
                                };
                                await _context.OtherSubsidyQns.AddAsync(data);
                                await _context.SaveChangesAsync();
                            }
                        }
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("OtherSubsidy Repo along with multiple repo(OtherSubsidyQns) create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
        #endregion
    }
}
