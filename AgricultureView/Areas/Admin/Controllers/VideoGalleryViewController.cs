using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideoGalleryViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public VideoGalleryViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        #region Playlist
        public async Task<IActionResult> Playlist()
        {
            var response = await _globalVeriable.GetMethod("Admin/VideoGallery/GetAllPlaylist");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<PlaylistViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<PlaylistViewModel>());
        }

        public async Task<IActionResult> CreatePlaylist(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/VideoGallery/GetPlaylistById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<PlaylistViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new PlaylistViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreatePlaylist(PlaylistViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/VideoGallery/CreatePlaylist", model);
            if (response.Status)
            {
                return RedirectToAction("Playlist");
            }
            return View(model);
        }
        #endregion
        public async Task<IActionResult> VideoGallery()
        {
            var response = await _globalVeriable.GetMethod("Admin/VideoGallery/GetAllVideoGallery");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<VideoGalleryViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<VideoGalleryViewModel>());
        }

        public async Task<IActionResult> CreateVideoGallery(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/VideoGallery/GetVideoGalleryById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<VideoGalleryViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new VideoGalleryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateVideoGallery(VideoGalleryViewModel model)
        {
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(model.Id.ToString()), "Id");
                formData.Add(new StringContent(model.PlaylistId.ToString()), "PlaylistId");
                formData.Add(new StringContent(model.Title), "Title");
                formData.Add(new StringContent(model.YoutubeURL??string.Empty), "YoutubeURL");
                formData.Add(new StringContent(model.Description??string.Empty), "Description");
                formData.Add(new StringContent(model.IsPublised.ToString()), "IsPublised");


                if (model.FilePoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.FilePoto.OpenReadStream());
                    formData.Add(photoContent, "FilePoto", model.FilePoto.FileName);
                }

                var response = await _globalVeriable.PostFileMethod("Admin/VideoGallery/CreateVideoGallery", formData);
                if (response.Status)
                {
                    return RedirectToAction("VideoGallery");
                }
            }
            return View(model);

        }
    }
}
