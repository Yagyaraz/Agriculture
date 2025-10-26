using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Agriculture.Areas.Admin.Repositories
{
    public class LibraryRepository : ILibrary
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<LibraryRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public LibraryRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<LibraryRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        public async Task<List<LibraryViewModel>> GetAllLibrary()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.Library.Where(x => wardId == 0 || x.CreatedWardId == wardId)
                .Select(x => new LibraryViewModel()
                {
                    Id = x.Id,
                    Description = x.Description,
                    Title = x.Title,
                    TypeId = x.TypeId,
                    FilePhotoPath = x.FilePath,
                }).ToListAsync();
        }

        public async Task<LibraryViewModel> GetLibraryById(int id)
        {
            return await _context.Library.Where(x => x.Id == id)
               .Select(x => new LibraryViewModel()
               {
                   Id = x.Id,
                   Description = x.Description,
                   Title = x.Title,
                   TypeId = x.TypeId,
                   FilePhotoPath = x.FilePath,
               }).FirstOrDefaultAsync() ?? new LibraryViewModel();
        }

        public async Task<LibraryDetailViewModel> GetLibraryDetailById(int id)
        {
            return await _context.Library.Where(x => x.Id == id)
               .Select(x => new LibraryDetailViewModel()
               {
                   Id = x.Id,
                   Description = x.Description,
                   TypeName = x.AgriSector.Name,
                   Title = x.Title,
                   TypeId = x.TypeId,
                   FilePhotoPath = x.FilePath,
               }).FirstOrDefaultAsync() ?? new LibraryDetailViewModel();
        }

        public async Task<bool> InsertUpdateLibrary(LibraryViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var photo = "";
                try
                {
                    if (model.Id > 0) 
                    { 
                        var app = await _context.Library.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if(model.FilePoto != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("Library", model.FilePoto, "Library").Result.FilePath;
                            if (app.FilePath != null)
                            {
                                await _utility.RemoveFileFormServer(app.FilePath);
                            }
                        }
                        if (app != null)
                        {
                            app.Description = model.Description;
                            app.Title = model.Title;
                            app.TypeId = model.TypeId;
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
                        if(model.FilePoto != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("Library", model.FilePoto, "Library").Result.FilePath;
                        }
                        int wardId = await _utility.GetWardNoForLogin_Role_User();

                        var data = new Library()
                        {
                            Description = model.Description,
                            Title = model.Title,
                            TypeId = model.TypeId,
                            FilePath = photo,
                            CreatedWardId = wardId,


                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.Library.AddAsync(data);
                        await _context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Library Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
