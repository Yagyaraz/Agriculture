namespace Agriculture.Areas.Admin.Models
{
    public class LibraryViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile FilePoto { get; set; }

        public string FilePhotoPath { get; set; }
    }
    public class LibraryDetailViewModel
    {
        public int Id { get; set; }
        public int TypeId { get; set; }
        public string TypeName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public IFormFile FilePoto { get; set; }

        public string FilePhotoPath { get; set; }
    }
}
