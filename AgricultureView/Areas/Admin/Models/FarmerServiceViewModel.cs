namespace AgricultureView.Areas.Admin.Models
{
    public class FarmerServiceViewModel
    {
        public int Id { get; set; }
        public int AgriSectorId { get; set; }
        public string Name { get; set; }
        public string AgriSectorName { get; set; }
        public string NameEng { get; set; }
    }
    public class FarmerServiceCardViewModel
    {
        public int Id { get; set; }
        public int FiscalYearId { get; set; }
        public string ServiceDate { get; set; }
        public int FarmerId { get; set; }

        public string TypeName { get; set; }
        public string ServiceName { get; set; }
        public string FiscalYearName { get; set; }
        public string FarmerName { get; set; }
        public string FarmerAddress { get; set; }
        public List<FarmerServiceCardDetailViewModel> FarmerServiceCardDetailList { get; set; } = new List<FarmerServiceCardDetailViewModel>();
    }
    public class FarmerServiceCardDetailViewModel
    {
        public int Id { get; set; }
        public int FarmerServiceCardId { get; set; }
        public int TypeId { get; set; }
        public int ServiceId { get; set; }
        public int UnitId { get; set; }
        public decimal Quantity { get; set; }
        public string Detail { get; set; }
    }
}