namespace Agriculture.Areas.Admin.Models
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class SubCategoryViewModel
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int CategoryUnitId { get; set; }
        public string Name { get; set; }

        public string CategoryName { get; set; }
        public string CategoryUnit { get; set; }
    }
    public class SubsidyViewModel
    {
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public int ProgramId { get; set; }
        public int ProjectId { get; set; }
        public string StartDate { get; set; }
        public DateTime? StartDateEng { get; set; }
        public string EndDate { get; set; }
        public DateTime? EndDateEng { get; set; }
        public List<SubsidyDetailViewModel> SubsidyDetailViewModelList { get; set; } = new List<SubsidyDetailViewModel>();
        public string ProgramName { get; set; }
        public string ProjectName { get; set; }
        public int AcquiredQty { get; set; }
    }
    public class SubsidyDetailViewModel
    {
        public int Id { get; set; }
        public int SubsidyId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int Quantity { get; set; }
    }
    public class OtherSubsidyViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string StartDate { get; set; }
        public DateTime? StartDateEng { get; set; }
        public string EndDate { get; set; }
        public DateTime? EndDateEng { get; set; }
        public string Description { get; set; }
        public string ProvidedBy { get; set; }
        public List<OtherSubsidyQnsViewModel> OtherSubsidyQnsViewModelList { get; set; } = new List<OtherSubsidyQnsViewModel>();
    }
    public class OtherSubsidyQnsViewModel
    {
        public int Id { get; set; }
        public int OtherSubsidyId { get; set; }
        public string Qns { get; set; }
    }


    #region Popupmodel
    public class SubsidyPopupViewModel
    {
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public int ProgramId { get; set; }
        public int ProjectId { get; set; }
        public string StartDate { get; set; }
        public DateTime? StartDateEng { get; set; }
        public string EndDate { get; set; }
        public DateTime? EndDateEng { get; set; }
        public List<SubsidyDetailPopupViewModel> SubsidyDetailPopupViewModelList { get; set; } = new List<SubsidyDetailPopupViewModel>();
        public string ProgramName { get; set; }
        public string ProjectName { get; set; }
    }
    public class SubsidyDetailPopupViewModel
    {
        public int Id { get; set; }
        public int SubsidyId { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryName { get; set; }
        public int Quantity { get; set; }
        public int RemainingQty { get; set; }
    }
    public class SaveRequestedSubsidyViewModel
    {
        public int Id { get; set; }
        public int SubsidyId { get; set; }
        public int Quantity { get; set; }
        public int TotalRequired { get; set; }
        public int FarmerId { get; set; }

    }
    #endregion
}
