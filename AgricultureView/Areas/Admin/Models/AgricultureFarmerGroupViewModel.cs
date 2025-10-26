using System.ComponentModel.DataAnnotations;

namespace AgricultureView.Areas.Admin.Models
{
    public class AgricultureFarmerGroupViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirmName { get; set; }
        [Required]
        public string FirmNameEng { get; set; }
        [Required]
        public string FirmEstdDate { get; set; }
        [Required]
        public string FirmPalikaName { get; set; }
        [Required]
        public int FirmWardNo { get; set; }
        [Required]
        public string FirmTolName { get; set; }
        [Required]
        public int AgriGroupTypeId { get; set; }
        [Required]
        public string FirmPanNo { get; set; }
        [Required]
        public string FirmDartaNo { get; set; }
        [Required]
        public string FirmRegDate { get; set; }
        [Required]
        public string FirmHitKoshAmt { get; set; }

        [Required]
        public int SadsyeMaleCount { get; set; }
        [Required]
        public int SadsyeFemaleCount { get; set; }
        [Required]
        public int SadsyeOtherCount { get; set; }
        public string SamuhaAim { get; set; }
        [Required]
        public string SamuhaDetails { get; set; }
        [Required]
        public int SamuhaWardNo { get; set; }
        [Required]
        public string KaryalayeName { get; set; }

        public string AgriGroupType { get; set; }

        public List<OfficialsDetailViewModel> OfficialsDetailViewModelList { get; set; } = new List<OfficialsDetailViewModel>();
    }
    public class OfficialsDetailViewModel
    {
        public int Id { get; set; }
        public int AgricultureFarmerGroupId { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public int PostId { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int LiterateLevelId { get; set; }
        [Required]
        public string Area { get; set; }
    }
}
