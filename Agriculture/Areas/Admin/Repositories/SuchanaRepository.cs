using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Agriculture.Areas.Admin.Repositories
{
    public class SuchanaRepository : ISuchana
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<SuchanaRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public SuchanaRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<SuchanaRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }
        public async Task<List<SuchanaViewModel>> GetAllSuchana()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.Suchanas.Where(x => wardId == 0 || x.CreatedWardId == wardId)
                .Select(x => new SuchanaViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    FilePath = x.FilePath,
                }).ToListAsync();
        }

        public async Task<SuchanaViewModel> GetSuchanaById(int id)
        {
            return await _context.Suchanas.Where(x => x.Id == id)
                          .Select(x => new SuchanaViewModel()
                          {
                              Id = x.Id,
                              Description = x.Description,
                              FilePath = x.FilePath,
                          }).FirstOrDefaultAsync() ?? new SuchanaViewModel();
        }

        public async Task<bool> InsertUpdateSuchana(SuchanaViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var photo = "";
                try
                {
                    if (model.Id > 0)
                    {
                        var app = await _context.Suchanas.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (model.FilePhoto != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("Suchana", model.FilePhoto, "Suchana").Result.FilePath;
                            if (app.FilePath != null)
                            {
                                await _utility.RemoveFileFormServer(app.FilePath);
                            }
                        }
                        if (app != null)
                        {
                            app.FiscalYearId = model.FiscalYearId;
                            app.Description = model.Description;
                            app.FilePath = photo == "" ? app.FilePath : photo;

                            app.UpdatedBy = _userId;
                            app.UpdatedDate = DateTime.Now;

                            _context.Entry(app).State = EntityState.Modified;
                            await _context.SaveChangesAsync();

                        }
                        else return false;

                    }
                    else
                    {
                        if (model.FilePhoto != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("Suchana", model.FilePhoto, "Suchana").Result.FilePath;
                        }
                        int wardId = await _utility.GetWardNoForLogin_Role_User();
                        var data = new Suchana()
                        {
                            FiscalYearId = model.FiscalYearId,

                            Description = model.Description,
                            FilePath = photo,

                            CreatedWardId = wardId,
                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.Suchanas.AddAsync(data);
                        await _context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Suchana Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
