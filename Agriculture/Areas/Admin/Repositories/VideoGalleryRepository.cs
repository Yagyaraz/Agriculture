using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Utilities;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Agriculture.Areas.Admin.Repositories
{
    public class VideoGalleryRepository : IVideoGallery
    {
        private readonly AgricultureDbContext _context;
        private readonly ILogger<ImageGalleryRepository> _logger;
        private readonly IUtility _utility;
        private readonly string _userId;
        public VideoGalleryRepository(AgricultureDbContext context, IHttpContextAccessor httpContextAccessor, IUtility utility, ILogger<ImageGalleryRepository> logger)
        {
            _context = context;
            _utility = utility;
            _userId = httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _logger = logger;
        }

        #region Playlist
        public async Task<List<PlaylistViewModel>> GetAllPlaylist()
        {
            int wardId = await _utility.GetWardNoForLogin_Role_User();
            return await _context.Playlist.Where(x => wardId == 0 || x.CreatedWardId == wardId)
                .Select(x => new PlaylistViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    IsPublised = x.IsPublised,
                    Publised = x.IsPublised == true ? "प्रकाशित" : "अप्रकाशित",
                }).ToListAsync();
        }
        public async Task<PlaylistViewModel> GetPlaylistById(int id)
        {
            return await _context.Playlist.Where(x => x.Id == id)
                       .Select(x => new PlaylistViewModel()
                       {
                           Id = x.Id,
                           Name = x.Name,
                           IsPublised = x.IsPublised,
                       }).FirstOrDefaultAsync() ?? new PlaylistViewModel();
        }
        public async Task<bool> InsertUpdatePlaylist(PlaylistViewModel model)
        {
            try
            {
                var data = _context.Playlist.FirstOrDefault(x => x.Id == model.Id);
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
                    var newdata = new Playlist()
                    {
                        Name = model.Name,
                        IsPublised = model.IsPublised,

                        CreatedWardId = wardId,
                        CreatedBy = _userId,
                        CreatedDate = DateTime.Now,
                    };
                    await _context.Playlist.AddAsync(newdata);
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


        public async Task<List<VideoGalleryViewModel>> GetAllVideoGallery()
        {
            return await _context.VideoGallery
                .Select(x => new VideoGalleryViewModel()
                {
                    Id = x.Id,
                    Title = x.Title,
                    PlaylistId= x.PlaylistId,
                    FilePath = x.FilePath,
                    IsPublised = x.IsPublised,
                    YoutubeURL = x.YoutubeURL,
                    Description = x.Description,
                    PlaylistName = x.Playlist.Name,
                    Publised = x.IsPublised == true ? "प्रकाशित" : "अप्रकाशित",
                }).ToListAsync();
        }
        public async Task<VideoGalleryViewModel> GetVideoGalleryById(int id)
        {
            return await _context.VideoGallery.Where(x => x.Id == id)
               .Select(x => new VideoGalleryViewModel()
               {
                   Id = x.Id,
                   Title = x.Title,
                   PlaylistId = x.PlaylistId,
                   FilePath = x.FilePath,
                   IsPublised = x.IsPublised,
                   YoutubeURL= x.YoutubeURL,
                   Description = x.Description,
               }).FirstOrDefaultAsync() ?? new VideoGalleryViewModel();
        }
        public async Task<bool> InsertUpdateVideoGallery(VideoGalleryViewModel model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                var photo = "";
                try
                {
                    if (model.Id > 0)
                    {
                        var app = await _context.VideoGallery.FirstOrDefaultAsync(x => x.Id == model.Id);
                        if (model.FilePoto != null)
                        {
                            photo = _utility.UploadImgReturnPathAndName("VideoGallery", model.FilePoto, "VideoGallery").Result.FilePath;
                            if (app.FilePath != null)
                            {
                                await _utility.RemoveFileFormServer(app.FilePath);
                            }
                        }
                        if (app != null)
                        {
                            app.Title = model.Title;
                            app.PlaylistId = model.PlaylistId;
                            app.IsPublised = model.IsPublised;
                            app.FilePath = photo == "" ? app.FilePath : photo;
                            app.YoutubeURL = model.YoutubeURL;
                            app.Description = model.Description;

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
                            photo = _utility.UploadImgReturnPathAndName("VideoGallery", model.FilePoto, "VideoGallery").Result.FilePath;
                        }
                        int wardId = await _utility.GetWardNoForLogin_Role_User();
                        var data = new VideoGallery()
                        {
                            Title = model.Title,
                            PlaylistId = model.PlaylistId,
                            IsPublised = model.IsPublised,
                            FilePath = photo,
                            YoutubeURL = model.YoutubeURL,
                            Description = model.Description,

                            CreatedWardId = wardId,
                            CreatedBy = _userId,
                            CreatedDate = DateTime.Now,
                        };
                        await _context.VideoGallery.AddAsync(data);
                        await _context.SaveChangesAsync();
                    }
                    await transaction.CommitAsync();
                    return true;
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("VideoGallery Repo create/update Error User Id = " + _userId + " Date : " + DateTime.Now + " Error log : " + ex);
                    await transaction.RollbackAsync();
                    return false;
                }
            }
        }
    }
}
