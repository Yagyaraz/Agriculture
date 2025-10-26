using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IVideoGallery
    {
        #region Playlist
        Task<List<PlaylistViewModel>> GetAllPlaylist();
        Task<PlaylistViewModel> GetPlaylistById(int id);
        Task<bool> InsertUpdatePlaylist(PlaylistViewModel model);
        #endregion


        Task<List<VideoGalleryViewModel>> GetAllVideoGallery();
        Task<VideoGalleryViewModel> GetVideoGalleryById(int id);
        Task<bool> InsertUpdateVideoGallery(VideoGalleryViewModel model);
    }
}
