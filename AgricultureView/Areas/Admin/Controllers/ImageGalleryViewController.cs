using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ImageGalleryViewController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public ImageGalleryViewController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }
        #region Album
        public async Task<IActionResult> Album()
        {
            var response = await _globalVeriable.GetMethod("Admin/ImageGallery/GetAllAlbum");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<AlbumViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<AlbumViewModel>());
        }

        public async Task<IActionResult> CreateAlbum(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/ImageGallery/GetAlbumById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<AlbumViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new AlbumViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateAlbum(AlbumViewModel model)
        {
            var response = await _globalVeriable.PostMethod("Admin/ImageGallery/CreateAlbum", model);
            if (response.Status)
            {
                return RedirectToAction("Album");
            }
            return View(model);
        }
        #endregion
        public async Task<IActionResult> ImageGallery()
        {
            var response = await _globalVeriable.GetMethod("Admin/ImageGallery/GetAllImageGallery");
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<List<ImageGalleryViewModel>>(response.Data.ToString());
                return View(dataa);
            }
            return View(new List<ImageGalleryViewModel>());
        }

        public async Task<IActionResult> CreateImageGallery(int id = 0)
        {
            var response = await _globalVeriable.GetMethod("Admin/ImageGallery/GetImageGalleryById/" + id);
            if (response.Status)
            {
                var dataa = JsonConvert.DeserializeObject<ImageGalleryViewModel>(response.Data.ToString());
                return View(dataa);
            }
            return View(new ImageGalleryViewModel());
        }
        [HttpPost]
        public async Task<IActionResult> CreateImageGallery(ImageGalleryViewModel model)
        {
            using (MultipartFormDataContent formData = new MultipartFormDataContent())
            {
                formData.Add(new StringContent(model.Id.ToString()), "Id");
                formData.Add(new StringContent(model.AlbumId.ToString()), "AlbumId");
                formData.Add(new StringContent(model.Title), "Title");
                formData.Add(new StringContent(model.IsPublised.ToString()), "IsPublised");


                if (model.FilePoto != null)
                {
                    StreamContent photoContent = new StreamContent(model.FilePoto.OpenReadStream());
                    formData.Add(photoContent, "FilePoto", model.FilePoto.FileName);
                }

                var response = await _globalVeriable.PostFileMethod("Admin/ImageGallery/CreateImageGallery", formData);
                if (response.Status)
                {
                    return RedirectToAction("ImageGallery");
                }
            }
            return View(model);

        }
    }
}
