using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface IImageGallery
    {
        #region Album
        Task<List<AlbumViewModel>> GetAllAlbum();
        Task<AlbumViewModel> GetAlbumById(int id);
        Task<bool> InsertUpdateAlbum(AlbumViewModel model);
        #endregion

        Task<List<ImageGalleryViewModel>> GetAllImageGallery();
        Task<ImageGalleryViewModel> GetImageGalleryById(int id);
        Task<bool> InsertUpdateImageGallery(ImageGalleryViewModel model);
    }
}
