namespace AgricultureView.Areas.Admin.Models
{
    public class LandingPageViewModel
    {
        public List<FarmerViewModel> Farmers { get; set; }
        public List<AgricultureProgramViewModel>Programs { get; set; }
        public List<AgricultureProjectViewModel> Projects { get; set; }
        public List<AgricultureServiceViewModel> Services { get; set; }
        public List<AgricultureServiceAdditionalViewModel> AdditionalServices { get; set; }
        public List<AgricultureFarmerGroupViewModel> FarmerGroups { get; set; }
        public List<AgriCalendarTypeViewModel> CalenderTypes { get; set; }
        public List<AgriCalendarTypeViewModel> AgriCalendarTypes { get; set; }
        public List<AgriCalendarCategoryViewModel> AgriCalendarCategories { get; set; }
        public List<AgriCalendarProductViewModel> AgriCalendarProducts { get; set; }
        public List<AgriCalendarViewModel> AgriCalendars { get; set; }
        public List<FarmerServiceViewModel> FarmerServices { get; set; }
        public List<FarmerServiceCardViewModel> FarmerServiceCards { get; set; }
        public List<AlbumViewModel> Albums { get; set; }
        public List<ImageGalleryViewModel> ImageGalleries { get; set; }
        public List<LibraryViewModel> Libraries { get; set; }
        public List<CommonViewModel> Markets { get; set; }
        public List<MarketPriceViewModel> MarketPrices { get; set; }
        public List<FertilizerStoreViewModel> FertilizerStores { get; set; }
        public List<SeedStoreViewModel> SeedStores { get; set; }
        public List<InsuranceCenterViewModel> InsuranceCenters { get; set; }
        public List<AgricultureEquipmentViewModel> AgricultureEquipments { get; set; }
        public List<CategoryViewModel> Categories { get; set; }
        public List<SubCategoryViewModel> SubCategories { get; set; }
        public List<SubsidyViewModel> SubsidiesForUser { get; set; }
        public List<SubsidyViewModel> Subsidies { get; set; }
        public List<OtherSubsidyViewModel> OtherSubsidies { get; set; }
        public List<TrainingViewModel> Trainings { get; set; }
        public List<PlaylistViewModel> Playlists { get; set; }
        public List<VideoGalleryViewModel> VideoGalleries { get; set; }
        public GunasoViewModel Gunaso { get; set; }

    }
}
