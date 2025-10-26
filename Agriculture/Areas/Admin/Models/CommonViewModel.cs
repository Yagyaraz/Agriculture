namespace Agriculture.Areas.Admin.Models
{
    public class FiscalYearViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_En { get; set; }
        public string Code { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public bool IsActive { get; set; }
        public string DateFrom { get; set; }
        public DateTime DateFromEng { get; set; }
        public string DateTo { get; set; }
        public DateTime DateToEng { get; set; }
        public int? PreviousFiscalYearId { get; set; }
    }
    public class OfficeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Name_En { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public string Address_En { get; set; }
        public string PhoneNo { get; set; }
        public string FaxNo { get; set; }
        public string Email { get; set; }
        public string Url { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int PalikaId { get; set; }
        public string StateName { get; set; }
        public string StateName_En { get; set; }
        public string DistrictName { get; set; }
        public string DistrictName_En { get; set; }
        public string PalikaName { get; set; }
        public string PalikaName_En { get; set; }
    }
    public class CommonViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
    }
  
    public class AnimalSetupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public bool IsSelect { get; set; }
    }
    public class BooleianViewModel
    {
        public int Id { get; set; }
        public bool IsSelect { get; set; }
    }
}
