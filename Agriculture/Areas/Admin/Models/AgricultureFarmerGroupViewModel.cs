namespace Agriculture.Areas.Admin.Models
{
    public class AgricultureFarmerGroupViewModel
    {
        public int Id { get; set; }
        public string FirmName { get; set; }
        public string FirmNameEng { get; set; }
        public string FirmEstdDate { get; set; }
        public string FirmPalikaName { get; set; }
        public int FirmWardNo { get; set; }
        public string FirmTolName { get; set; }
        public int AgriGroupTypeId { get; set; }
        public string FirmPanNo { get; set; }
        public string FirmDartaNo { get; set; }
        public string FirmRegDate { get; set; }
        public string FirmHitKoshAmt { get; set; }

        public int SadsyeMaleCount { get; set; }
        public int SadsyeFemaleCount { get; set; }
        public int SadsyeOtherCount { get; set; }
        public string SamuhaAim { get; set; }
        public string SamuhaDetails { get; set; }
        public int SamuhaWardNo { get; set; }
        public string KaryalayeName { get; set; }
        public string AgriGroupType { get; set; }
        public List<OfficialsDetailViewModel> OfficialsDetailViewModelList { get; set; } = new List<OfficialsDetailViewModel>();
    }
    public class OfficialsDetailViewModel
    {
        public int Id { get; set; }
        public int AgricultureFarmerGroupId { get; set; }

        public string FullName { get; set; }
        public int PostId { get; set; }
        public int Age { get; set; }
        public int LiterateLevelId { get; set; }
        public string Area { get; set; }
    }
}
