using Agriculture.Areas.Admin.Interface;
using Agriculture.Areas.Admin.Models;
using Agriculture.Data;
using Agriculture.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Agriculture.Areas.Admin.Controllers
{
    [Route("api/Admin/[controller]")]
    [ApiController]
    public class VideoGalleryController : ControllerBase
    {
        private readonly IVideoGallery _VideoGallery;

        public VideoGalleryController(IVideoGallery videoGallery)
        {
            _VideoGallery = videoGallery;
        }
        #region Playlist

        [HttpGet("GetAllPlaylist")]
        public async Task<IActionResult> GetAllPlaylist()
        {
            var data = await _VideoGallery.GetAllPlaylist();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetPlaylistById/{id}")]
        public async Task<IActionResult> GetPlaylistById(int id = 0)
        {
            var data = await _VideoGallery.GetPlaylistById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreatePlaylist")]
        public async Task<IActionResult> CreatePlaylist(PlaylistViewModel model)
        {
            var data = await _VideoGallery.InsertUpdatePlaylist(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion

        #region VideoGallery

        [HttpGet("GetAllVideoGallery")]
        public async Task<IActionResult> GetAllVideoGallery()
        {
            var data = await _VideoGallery.GetAllVideoGallery();
            return Ok(new ApiResponse { Status = data.Any(), Message = data.Any() ? "Successfully Generated All List" : "Not Generated Try Again", Data = data });

        }
        [HttpGet("GetVideoGalleryById/{id}")]
        public async Task<IActionResult> GetVideoGalleryById(int id = 0)
        {
            var data = await _VideoGallery.GetVideoGalleryById(id);
            return Ok(new ApiResponse { Status = data != null, Message = data != null ? "Successfully Fetched data According to Id" : "Not Fetched Try Again", Data = data });
        }
        [HttpPost("CreateVideoGallery")]
        public async Task<IActionResult> CreateVideoGallery([FromForm] VideoGalleryViewModel model)
        {
            var data = await _VideoGallery.InsertUpdateVideoGallery(model);
            return Ok(new ApiResponse { Status = data, Message = data ? "Successfully Created" : "Not Created Try Again", Data = data });
        }
        #endregion
    }
}
