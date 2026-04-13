namespace AgricultureView.Areas.Admin.Models
{
    public class GunasoViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string FilePath { get; set; }
        public IFormFile FilePhoto { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
