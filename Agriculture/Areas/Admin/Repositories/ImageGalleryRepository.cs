using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Agriculture.Areas.Admin.Repositories
{
    public class ImageGalleryRepository : IImageGallery
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<ImageGalleryRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public ImageGalleryRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<ImageGalleryRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        #region Album
        public async Task<List<AlbumViewModel>> GetAllAlbum()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.Album.Where(x => wardId == 0 || x.CreatedWardId == wardId)
                .Select(x => new AlbumViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsPublised = x.IsPublised,
                    Publised = x.IsPublised == true ? "प्रकाशित" : "अप्रकाशित",
                }).ToListAsync();
        }
        public async Task<AlbumViewModel> GetAlbumById(int id)
        {
            return await _context.Album.Where(x => x.Id == id)
                       .Select(x => new AlbumViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           IsPublised = x.IsPublised,
                       }).FirstOrDefaultAsync() ?? new AlbumViewModel();
        }
        public async Task<bool> InsertUpdateAlbum(AlbumViewModel model)
        {
            try
            {
                var data = _context.Album.FirstOrDefault(x => x.Id == model.Id);
                if (data != null)
                {
                    data.Name = model.Name;
                    data.IsPublised = model.IsPublised;

                    data.UpdatedBy = _userId;
                    data.UpdatedDate = DateTime.Now;

                    _context.Entry(data).State = EntityState.Modified;
                }
                else
                {
                    int wardId = await _utility.GetWardNoForLogin_Role_User();

                    var newdata = new Album()
                    {
                        Name = model.Name,
                        IsPublised = model.IsPublised,

                        CreatedBy = _userId,
                        CreatedDate = DateTime.Now,
                        CreatedWardId = wardId,

                    };
                    await _context.Album.AddAsync(newdata);
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

        public async Task<List<ImageGalleryViewModel>> GetAllImageGallery()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.ImageGallery.Where(x => wardId == 0 || x.CreatedWardId == wardId)
                .Select(x => new ImageGalleryViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    AlbumId = x.AlbumId,
                    FilePath = x.FilePath,
                    IsPublised = x.IsPublised,

                    AlbumName = x.Album.Name,
                    Publised = x.IsPublised == true ? "प्रकाशित" : "अप्रकाशित",
                }).ToListAsync();
        }
        public async Task<ImageGalleryViewModel> GetImageGalleryById(int id)
        {
            return await _context.ImageGallery.Where(x => x.Id == id)
               .Select(x => new ImageGalleryViewModel()
               {
                   Id = x.Id,
                   Title = x.Title,
                   AlbumId = x.AlbumId,
                   FilePath = x.FilePath,
                   IsPublised = x.IsPublised
               }).FirstOrDefaultAsync() ?? new ImageGalleryViewModel();
        }
        public async Task<bool> InsertUpdateImageGallery(ImageGalleryViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var photo = "";
                try
                {
                    if (model.Id > 0)
                    {
                        var app = await _context.ImageGallery.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (model.FilePoto != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("ImageGallery", model.FilePoto, "ImageGallery").Result.FilePath;
                            if (app.FilePath != null)
                            {
                                await _utility.RemoveFileFormServer(app.FilePath);
                            }
                        }
                        if (app != null)
                        {
                            app.Title = model.Title;
                            app.AlbumId = model.AlbumId;
                            app.IsPublised = model.IsPublised;
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
                        if (model.FilePoto != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("ImageGallery", model.FilePoto, "ImageGallery").Result.FilePath;
                        }
                        int wardId = await _utility.GetWardNoForLogin_Role_User();

                        var data = new ImageGallery()
                        {
                            Title = model.Title,
                            AlbumId = model.AlbumId,
                            IsPublised = model.IsPublised,
                            FilePath = photo,

                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                            CreatedWardId = wardId,

                        };
                        await _context.ImageGallery.AddAsync(data);
                        await _context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("ImageGallery Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
