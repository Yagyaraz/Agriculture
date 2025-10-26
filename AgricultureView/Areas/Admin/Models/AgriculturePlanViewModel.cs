using System.ComponentModel.DataAnnotations;

namespace AgricultureView.Areas.Admin.Models
{
    public class AgricultureProgramViewModel
    {
        public int Id { get; set; }
        public int FiscalYearId { get; set; }

        public string Title { get; set; }

        public string FiscalYearName { get; set; }

    }

    public class AgricultureProjectViewModel
    {
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public int ProgramId { get; set; }
        public string ProjectName { get; set; }

        public string FiscalYearName { get; set; }
        public string ProgramName { get; set; }
    }


    public class AgricultureServiceViewModel
    {
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public int ProgramId { get; set; }
        public int ProjectId { get; set; }
        public string ValidTillDate { get; set; }
        public DateTime? ValidTillDateEng { get; set; }
        public string ServiceName { get; set; }


        public string FiscalYearName { get; set; }
        public string ProjectName { get; set; }
        public string ProgramName { get; set; }
        public List<AgricultureServiceAdditionalViewModel> AgricultureServiceAdditionalViewModelList { get; set; } = new List<AgricultureServiceAdditionalViewModel>();
    }
    public class AgricultureServiceAdditionalViewModel
    {
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Questions { get; set; }
    }
    public class AgricultureApplicatoionFormViewModel
    {
        public int Id { get; set; }
        [Required]
        public int FiscalYearId { get; set; }
        [Required]
        public int ProgramId { get; set; }
        [Required]
        public int ProjectId { get; set; }
        [Required]
        public int ServiceId { get; set; }

        [Required]
        public int FarmerTypeId { get; set; }
        public int? FarmerId { get; set; }
        public int? AgriGroupId { get; set; }
        public string ContactName { get; set; }
        public string Remarks { get; set; }

        public IFormFile CitizenPhoto { get; set; }
        public IFormFile LandOwnershipPhoto { get; set; }
        public IFormFile PlanDetailPhoto { get; set; }
        public IFormFile PanjikaranPhoto{ get; set; }
        public IFormFile SthailekhaPhoto{ get; set; }
        public IFormFile TaxPhoto{ get; set; }
        public IFormFile MinutePhoto{ get; set; }
        public IFormFile SelfdecisionPhoto{ get; set; }

        public string FiscalYearName { get; set; }
        public string ProgramName { get; set; }
        public string ProjectName { get; set; }
        public string ServiceName { get; set; }
        public string FarmerorAgriGroupName { get; set; }
        public string FarmerType { get; set; }
        public string CitizenPhotoPath { get; set; }
        public string LandOwnershipPhotoPath { get; set; }
        public string PlanDetailPhotoPath { get; set; }
        public string PanjikaranPhotoPath { get; set; }
        public string SthailekhaPhotoPath { get; set; }
        public string TaxPhotoPath { get; set; }
        public string MinutePhotoPath { get; set; }
        public string SelfdecisionPhotoPath { get; set; }
    }
}
