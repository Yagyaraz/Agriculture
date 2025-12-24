using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class Farmer
    {
        [Key]
        public int Id { get; set; }
        public string FullName { get; set; }
        public string FullNameEng { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int PalikaId { get; set; }
        public int WardNo { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public int GenderId { get; set; }
        public string DOBNep { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DOBEng { get; set; }
        public int EducationId { get; set; }
        public int? EducationLevelId { get; set; }
        public string TolName { get; set; }
        public string CitizenNo { get; set; }
        public int CitizenDistricrId { get; set; }
        public string CitizenIssueDate { get; set; }
        public int FarmerGroupId { get; set; }
        public int FarmerCategoryId { get; set; }
        public string HouseNo { get; set; }
        public int CreatedWardId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(StateId))]
        public State State { get; set; }
        [ForeignKey(nameof(DistrictId))]
        public District District { get; set; }
        [ForeignKey(nameof(PalikaId))]
        public Palika Palika { get; set; }       
        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; }
        [ForeignKey(nameof(EducationId))]
        public Education Education { get; set; }
        [ForeignKey(nameof(FarmerGroupId))]
        public FarmerGroup FarmerGroup { get; set; }
        [ForeignKey(nameof(FarmerCategoryId))]
        public FarmerCategory FarmerCategory { get; set; }
        [ForeignKey(nameof(EducationLevelId))]
        public EducationLevel EducationLevel { get; set; }
    }
   public class FarmerFile
    {
        [Key]
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public string ProfilePicName { get; set; }
        public string ProfilePicPath { get; set; }
        public string CitizenFrontPicName{ get; set; }
        public string CitizenFrontPicPath { get; set; }
        public string CitizenBackPicName { get; set; }
        public string CitizenBackPicPath { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; } 
    }
}
