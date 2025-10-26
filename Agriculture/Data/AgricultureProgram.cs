using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class AgricultureProgram
    {
        [Key]
        public int Id { get; set; }
        public int FiscalYearId { get; set; }

        public string Title { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedWardId { get; set; }


        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
    }
    public class AgricultureProject
    {
        [Key]
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public int ProgramId { get; set; }
        public string ProjectName { get; set; }
        public int CreatedWardId { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public AgricultureProgram AgricultureProgram { get; set; }
    }
    public class AgricultureService
    {
        [Key] 
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public int ProgramId { get; set; }
        public int ProjectId { get; set; }
        public string ValidTillDate { get; set; }
        public DateTime? ValidTillDateEng { get; set; }
        public string ServiceName { get; set; }
        public int CreatedWardId { get; set; }



        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public AgricultureProgram AgricultureProgram { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public AgricultureProject AgricultureProject { get; set; }
    }
    public class AgricultureServiceAdditional
    {
        [Key]
        public int Id { get; set; }
        public int ServiceId { get; set; }
        public string Questions { get; set; }


        [ForeignKey(nameof(ServiceId))]
        public AgricultureService AgricultureService { get; set; }
    }

    public class AgricultureApplicatoionForm
    {
        [Key]
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public int ProgramId { get; set; }
        public int ProjectId { get; set; }
        public int ServiceId { get; set; }

        public int FarmerTypeId { get; set; }
        public int? FarmerId { get; set; }
        public int? AgriGroupId { get; set; }
        public string ContactName { get; set; }
        public string Remarks { get; set; }

        public string CitizenPhotoPath { get; set; }
        public string LandOwnershipPhotoPath { get; set; }
        public string PlanDetailPhotoPath { get; set; }
        public string PanjikaranPhotoPath { get; set; }
        public string SthailekhaPhotoPath { get; set; }
        public string TaxPhotoPath { get; set; }
        public string MinutePhotoPath { get; set; }
        public string SelfdecisionPhotoPath { get; set; }


        public int? Approvestatus { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedWardId { get; set; }


        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public AgricultureProgram AgricultureProgram { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public AgricultureProject AgricultureProject { get; set; }
        [ForeignKey(nameof(ServiceId))]
        public AgricultureService AgricultureService { get; set; }
        [ForeignKey(nameof(AgriGroupId))]
        public FarmerGroup FarmerGroup { get; set; }
        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; }
    }
}
