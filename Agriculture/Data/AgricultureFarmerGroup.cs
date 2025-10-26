using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace Agriculture.Data
{
    public class AgricultureFarmerGroup
    {
        [Key]
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

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedWardId { get; set; }


        [ForeignKey(nameof(AgriGroupTypeId))]
        public AgriGroupType AgriGroupType { get; set; }
    }
    public class OfficialsDetail
    {
        [Key]
        public int Id { get; set; }
        public int AgricultureFarmerGroupId { get; set; }

        public string FullName { get; set; }
        public int PostId { get; set; }
        public int Age { get; set; }
        public int LiterateLevelId { get; set; }
        public string Area { get; set; }

        [ForeignKey(nameof(AgricultureFarmerGroupId))]
        public AgricultureFarmerGroup AgricultureFarmerGroup { get; set; }
        [ForeignKey(nameof(LiterateLevelId))]
        public EducationLevel EducationLevel { get; set; }
        [ForeignKey(nameof(PostId))]
        public Post Post { get; set; }
    }

    public class AgriGroupType
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
}
