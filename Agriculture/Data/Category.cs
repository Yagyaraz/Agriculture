using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatedWardId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class SubCategory
    {
        [Key]
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CategoryUnitId { get; set; }
        public string Name { get; set; }
        public int CreatedWardId { get; set; }
        public bool IsDeleted { get; set; } = false;

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        [ForeignKey(nameof(CategoryUnitId))]
        public MeasuringUnit MeasuringUnit { get; set; }
    }
    public class MeasuringUnit
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
    public class Subsidy
    {
        [Key]
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public int ProgramId { get; set; }
        public int ProjectId { get; set; }
        public string StartDate { get; set; }
        public DateTime? StartDateEng { get; set; }
        public string EndDate { get; set; }
        public DateTime? EndDateEng { get; set; }

        public int CreatedWardId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; } = false;


        [ForeignKey(nameof(FiscalYearId))]
        public FiscalYear FiscalYear { get; set; }
        [ForeignKey(nameof(ProgramId))]
        public AgricultureProgram AgricultureProgram { get; set; }
        [ForeignKey(nameof(ProjectId))]
        public AgricultureProject AgricultureProject { get; set; }
    }
    public class SubsidyDetail
    {
        [Key]
        public int Id { get; set; }
        public int SubsidyId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int Quantity { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        [ForeignKey(nameof(SubsidyId))]
        public Subsidy Subsidy { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; }
        [ForeignKey(nameof(SubCategoryId))]
        public SubCategory SubCategory { get; set; }
    }
    public class OtherSubsidy
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public DateTime? StartDateEng { get; set; }
        public string EndDate { get; set; }
        public DateTime? EndDateEng { get; set; }
        public string Description { get; set; }
        public string ProvidedBy { get; set; }
        public bool IsDeleted { get; set; } = false;

        public int CreatedWardId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class OtherSubsidyQns
    {
        [Key]
        public int Id { get; set; }
        public int OtherSubsidyId { get; set; }
        public string Qns { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey(nameof(OtherSubsidyId))]
        public OtherSubsidy OtherSubsidy { get; set; }
    }
}
