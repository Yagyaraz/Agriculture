using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class FamilyDetails
    {
        [Key]
        public int Id { get; set; }
        public int FarmerId { get; set; }
        public int FiscalYearId { get; set; }

        public int TotalMale { get; set; }
        public int TotalFemale { get; set; }
        public int TotalMember { get; set; }
        public int TotalMaleInAgri { get; set; }
        public int TotalFemaleInAgri { get; set; }
        public int TotalMemberInAgri { get; set; }

        public int TotalInvolvedinAgi { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(FarmerId))]
        public Farmer Farmer { get; set; }
        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
    }
    public class FamilyDetailsInvolvedInAgri
    {
        [Key]
        public int Id { get; set; }
        public int FamilyDetailsId { get; set; }
        public int RelationId { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int GenderId { get; set; }
        public int WorkingAreaId { get; set; }
        public string CitizenNo { get; set; }
        public string PhoneNumbar { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }


        [ForeignKey(nameof(FamilyDetailsId))]
        public FamilyDetails FamilyDetails { get; set; }
        [ForeignKey(nameof(RelationId))]
        public Relation Relation { get; set; }
        [ForeignKey(nameof(GenderId))]
        public Gender Gender { get; set; }
        [ForeignKey(nameof(WorkingAreaId))]
        public WorkingArea WorkingArea { get; set; }
    }

    public class WorkingArea
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
}
