using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class ImageGalleryController : ControllerBase
    {
        private readonly IImageGallery _Album;

        public ImageGalleryController(IImageGallery imageAlbum)
        {
            _Album = imageAlbum;
        }
        #region Album

        [HttpGet("GetAllAlbum")]
        public async Task<IActionResult> GetAllAlbum()
        {
            var data = await _Album.GetAllAlbum();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetAlbumById/{id}")]
        public async Task<IActionResult> GetAlbumById(int id = 0)
        {
            var data = await _Album.GetAlbumById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateAlbum")]
        public async Task<IActionResult> CreateAlbum(AlbumViewModel model)
        {
            var data = await _Album.InsertUpdateAlbum(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion

        #region ImageGallery

        [HttpGet("GetAllImageGallery")]
        public async Task<IActionResult> GetAllImageGallery()
        {
            var data = await _Album.GetAllImageGallery();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetImageGalleryById/{id}")]
        public async Task<IActionResult> GetImageGalleryById(int id = 0)
        {
            var data = await _Album.GetImageGalleryById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateImageGallery")]
        public async Task<IActionResult> CreateImageGallery([FromForm]ImageGalleryViewModel model)
        {
            var data = await _Album.InsertUpdateImageGallery(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
    }
}
