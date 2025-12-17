using AgricultureView.Areas.Admin.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Controllers
{
    [AllowAnonymous]
    public class LandingPageController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        public LandingPageController(IGlobalVeriable globalVeriable)
        {
            _globalVeriable = globalVeriable;
        }

        public async Task<IActionResult> Index()
        {
            var model = new LandingPageViewModel();
            var programResponse = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllProgram");
            if (programResponse.Status)
            {
                model.Programs = JsonConvert.DeserializeObject<List<AgricultureProgramViewModel>>(programResponse.Data.ToString());
            }
            var projectResponse = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllProject");
            if (projectResponse.Status)
            {
                model.Projects = JsonConvert.DeserializeObject<List<AgricultureProjectViewModel>>(projectResponse.Data.ToString());
            }
            var serviceResponse = await _globalVeriable.GetMethod("Admin/AgriculturePlan/GetAllService");
            if (serviceResponse.Status)
            {
                model.Services = JsonConvert.DeserializeObject<List<AgricultureServiceViewModel>>(serviceResponse.Data.ToString());
            }
            var farmerRsponse = await _globalVeriable.GetMethod("Admin/Farmer/GetAllFarmer");
            if (farmerRsponse.Status)
            {
                model.Farmers = JsonConvert.DeserializeObject<List<FarmerViewModel>>(farmerRsponse.Data.ToString());
            }
            var agriCalendarTypeResponse = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendarType");
            if (agriCalendarTypeResponse.Status)
            {
                model.AgriCalendarTypes = JsonConvert.DeserializeObject<List<AgriCalendarTypeViewModel>>(agriCalendarTypeResponse.Data.ToString());
            }
            var agriCalendarCategoryResponse = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendarCategory");
            if (agriCalendarCategoryResponse.Status)
            {
                model.AgriCalendarCategories = JsonConvert.DeserializeObject<List<AgriCalendarCategoryViewModel>>(agriCalendarCategoryResponse.Data.ToString());
            }

            var agriCalendarProductResponse = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendarProduct");
            if (agriCalendarProductResponse.Status)
            {
                model.AgriCalendarProducts = JsonConvert.DeserializeObject<List<AgriCalendarProductViewModel>>(agriCalendarProductResponse.Data.ToString());
            }

            var agriCalendarResponse = await _globalVeriable.GetMethod("Admin/AgriCalendar/GetAllAgriCalendar");
            if (agriCalendarResponse.Status)
            {
                model.AgriCalendars = JsonConvert.DeserializeObject<List<AgriCalendarViewModel>>(agriCalendarResponse.Data.ToString());
            }
            var farmerServiceResponse = await _globalVeriable.GetMethod("Admin/FarmerService/GetAllFarmerService");
            if (farmerServiceResponse.Status)
            {
                model.FarmerServices = JsonConvert.DeserializeObject<List<FarmerServiceViewModel>>(farmerServiceResponse.Data.ToString());
            }

            var farmerServiceCardResponse = await _globalVeriable.GetMethod("Admin/FarmerService/GetAllFarmerServiceCard");
            if (farmerServiceCardResponse.Status)
            {
                model.FarmerServiceCards = JsonConvert.DeserializeObject<List<FarmerServiceCardViewModel>>(farmerServiceCardResponse.Data.ToString());
            }
            var albumResponse = await _globalVeriable.GetMethod("Admin/ImageGallery/GetAllAlbum");
            if (albumResponse.Status)
            {
                model.Albums = JsonConvert.DeserializeObject<List<AlbumViewModel>>(albumResponse.Data.ToString());
            }

            var imageGalleryResponse = await _globalVeriable.GetMethod("Admin/ImageGallery/GetAllImageGallery");
            if (imageGalleryResponse.Status)
            {
                model.ImageGalleries = JsonConvert.DeserializeObject<List<ImageGalleryViewModel>>(imageGalleryResponse.Data.ToString());
            }
            var libraryResponse = await _globalVeriable.GetMethod("Admin/Library/GetAllLibrary");
            if (libraryResponse.Status)
            {
                model.Libraries = JsonConvert.DeserializeObject<List<LibraryViewModel>>(libraryResponse.Data.ToString());
            }

            var marketResponse = await _globalVeriable.GetMethod("Admin/MarketPrice/GetAllMarket");
            if (marketResponse.Status)
            {
                model.Markets = JsonConvert.DeserializeObject<List<CommonViewModel>>(marketResponse.Data.ToString());
            }

            var marketPriceResponse = await _globalVeriable.GetMethod("Admin/MarketPrice/GetAllMarketPrice");
            if (marketPriceResponse.Status)
            {
                model.MarketPrices = JsonConvert.DeserializeObject<List<MarketPriceViewModel>>(marketPriceResponse.Data.ToString());
            }
            var fertilizerStoreResponse = await _globalVeriable.GetMethod("Admin/StoresCenter/GetAllFertilizerStore");
            if (fertilizerStoreResponse.Status)
            {
                model.FertilizerStores = JsonConvert.DeserializeObject<List<FertilizerStoreViewModel>>(fertilizerStoreResponse.Data.ToString());
            }

            var seedStoreResponse = await _globalVeriable.GetMethod("Admin/StoresCenter/GetAllSeedStore");
            if (seedStoreResponse.Status)
            {
                model.SeedStores = JsonConvert.DeserializeObject<List<SeedStoreViewModel>>(seedStoreResponse.Data.ToString());
            }

            var insuranceCenterResponse = await _globalVeriable.GetMethod("Admin/StoresCenter/GetAllInsuranceCenter");
            if (insuranceCenterResponse.Status)
            {
                model.InsuranceCenters = JsonConvert.DeserializeObject<List<InsuranceCenterViewModel>>(insuranceCenterResponse.Data.ToString());
            }

            var agricultureEquipmentResponse = await _globalVeriable.GetMethod("Admin/StoresCenter/GetAllAgricultureEquipment");
            if (agricultureEquipmentResponse.Status)
            {
                model.AgricultureEquipments = JsonConvert.DeserializeObject<List<AgricultureEquipmentViewModel>>(agricultureEquipmentResponse.Data.ToString());
            }
            var categoryResponse = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllCategory");
            if (categoryResponse.Status)
            {
                model.Categories = JsonConvert.DeserializeObject<List<CategoryViewModel>>(categoryResponse.Data.ToString());
            }

            var subCategoryResponse = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllSubCategory");
            if (subCategoryResponse.Status)
            {
                model.SubCategories = JsonConvert.DeserializeObject<List<SubCategoryViewModel>>(subCategoryResponse.Data.ToString());
            }

            var subsidyForUserResponse = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllSubsidyForUser");
            if (subsidyForUserResponse.Status)
            {
                model.SubsidiesForUser = JsonConvert.DeserializeObject<List<SubsidyViewModel>>(subsidyForUserResponse.Data.ToString());
            }

            var subsidyResponse = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllSubsidy");
            if (subsidyResponse.Status)
            {
                model.Subsidies = JsonConvert.DeserializeObject<List<SubsidyViewModel>>(subsidyResponse.Data.ToString());
            }

            var otherSubsidyResponse = await _globalVeriable.GetMethod("Admin/Subsidy/GetAllOtherSubsidy");
            if (otherSubsidyResponse.Status)
            {
                model.OtherSubsidies = JsonConvert.DeserializeObject<List<OtherSubsidyViewModel>>(otherSubsidyResponse.Data.ToString());
            }
            var trainingResponse = await _globalVeriable.GetMethod("Admin/Training/GetAllTraining");
            if (trainingResponse.Status)
            {
                model.Trainings = JsonConvert.DeserializeObject<List<TrainingViewModel>>(trainingResponse.Data.ToString());
            }

            var playlistResponse = await _globalVeriable.GetMethod("Admin/VideoGallery/GetAllPlaylist");
            if (playlistResponse.Status)
            {
                model.Playlists = JsonConvert.DeserializeObject<List<PlaylistViewModel>>(playlistResponse.Data.ToString());
            }

            var videoGalleryResponse = await _globalVeriable.GetMethod("Admin/VideoGallery/GetAllVideoGallery");
            if (videoGalleryResponse.Status)
            {
                model.VideoGalleries = JsonConvert.DeserializeObject<List<VideoGalleryViewModel>>(videoGalleryResponse.Data.ToString());
            }
            var suchanaResponse = await _globalVeriable.GetMethod("Admin/Suchana/GetAllSuchana");
            if (suchanaResponse.Status)
            {
                model.Suchana = JsonConvert.DeserializeObject<List<SuchanaViewModel>>(suchanaResponse.Data.ToString());
            }
            return View(model);
        }
    }
}
