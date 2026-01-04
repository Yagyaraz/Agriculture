namespace AgricultureView.Areas.Admin.Models
{
    public class LandingPageViewModel
    {
        public List<FarmerViewModel> Farmers { get; set; } = new List<FarmerViewModel>();
        public List<AgricultureProgramViewModel>Programs { get; set; }=new List<AgricultureProgramViewModel>();
        public List<AgricultureProjectViewModel> Projects { get; set; } = new List<AgricultureProjectViewModel>();
        public List<AgricultureServiceViewModel> Services { get; set; } = new List<AgricultureServiceViewModel>();
        //public List<AgricultureServiceAdditionalViewModel> AdditionalServices { get; set; } = new List<AgricultureServiceAdditionalViewModel>();
        public List<AgricultureFarmerGroupViewModel> FarmerGroups { get; set; } = new List<AgricultureFarmerGroupViewModel>();
        public List<AgriCalendarTypeViewModel> CalenderTypes { get; set; } = new List<AgriCalendarTypeViewModel>();
        public List<AgriCalendarTypeViewModel> AgriCalendarTypes { get; set; } = new List<AgriCalendarTypeViewModel>();
        public List<AgriCalendarCategoryViewModel> AgriCalendarCategories { get; set; } = new List<AgriCalendarCategoryViewModel>();
        public List<AgriCalendarProductViewModel> AgriCalendarProducts { get; set; } = new List<AgriCalendarProductViewModel>();
        public List<AgriCalendarViewModel> AgriCalendars { get; set; } = new List<AgriCalendarViewModel>();
        public List<FarmerServiceViewModel> FarmerServices { get; set; } = new List<FarmerServiceViewModel>();
        public List<FarmerServiceCardViewModel> FarmerServiceCards { get; set; } = new List<FarmerServiceCardViewModel>();
        public List<AlbumViewModel> Albums { get; set; } = new List<AlbumViewModel>();
        public List<ImageGalleryViewModel> ImageGalleries { get; set; } = new List<ImageGalleryViewModel>();
        public List<LibraryViewModel> Libraries { get; set; } = new List<LibraryViewModel>();
        public List<CommonViewModel> Common { get; set; } = new List<CommonViewModel>();
        public List<MarketPriceViewModel> MarketPrices { get; set; } = new List<MarketPriceViewModel>();
        public List<FertilizerStoreViewModel> FertilizerStores { get; set; } = new List<FertilizerStoreViewModel>();
        public List<SeedStoreViewModel> SeedStores { get; set; } = new List<SeedStoreViewModel>();
        public List<InsuranceCenterViewModel> InsuranceCenters { get; set; } = new List<InsuranceCenterViewModel>();
        public List<AgricultureEquipmentViewModel> AgricultureEquipments { get; set; } = new List<AgricultureEquipmentViewModel>();
        public List<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
        public List<SubCategoryViewModel> SubCategories { get; set; } = new List<SubCategoryViewModel>();
        public List<SubsidyViewModel> SubsidiesForUser { get; set; } = new List<SubsidyViewModel>();
        public List<SubsidyViewModel> Subsidies { get; set; } = new List<SubsidyViewModel>();
        public List<OtherSubsidyViewModel> OtherSubsidies { get; set; } = new List<OtherSubsidyViewModel>();
        public List<TrainingViewModel> Trainings { get; set; } = new List<TrainingViewModel>();
        public List<PlaylistViewModel> Playlists { get; set; } = new List<PlaylistViewModel>();
        public List<VideoGalleryViewModel> VideoGalleries { get; set; } = new List<VideoGalleryViewModel>();
        public GunasoViewModel Gunaso { get; set; } =new GunasoViewModel();
        public List<SuchanaViewModel> Suchana { get; set; } = new List<SuchanaViewModel>();

    }
}
