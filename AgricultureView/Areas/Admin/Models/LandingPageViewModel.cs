namespace AgricultureView.Areas.Admin.Models
{
    public class LandingPageViewModel
    {
        public List<FarmerViewModel> Farmers { get; set; }
        public List<AgricultureProgramViewModel>Programs { get; set; }
        public List<AgricultureProjectViewModel> Projects { get; set; }
        public List<AgricultureServiceViewModel> Services { get; set; }
        public List<AgricultureServiceAdditionalViewModel> AdditionalServices { get; set; }


    }
}
