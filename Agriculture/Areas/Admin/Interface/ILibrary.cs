using Agriculture.Areas.Admin.Models;

namespace Agriculture.Areas.Admin.Interface
{
    public interface ILibrary
    {
        Task<List<LibraryViewModel>> GetAllLibrary();
        Task<LibraryViewModel> GetLibraryById(int id);
        Task<LibraryDetailViewModel> GetLibraryDetailById(int id);
        Task<bool> InsertUpdateLibrary(LibraryViewModel model);
    }
}
