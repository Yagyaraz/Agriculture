namespace AgricultureView.Areas.Admin.Models
{
    public class SuchanaViewModel
    {
        public int Id { get; set; }
        public string Title {  get; set; }
        public string Description { get; set; }
        public string FilePath { get; set; }
        public IFormFile FilePhoto { get; set; }
        public int FiscalYearId { get; set; }
        public string FiscalYearName { get; set; }
    }
}
