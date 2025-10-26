namespace Agriculture.Areas.Admin.Models
{
    public class AlbumViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublised { get; set; }
        public string Publised { get; set; }
    }
    public class ImageGalleryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public bool IsPublised { get; set; }
        public string FilePath { get; set; }
        public IFormFile FilePoto { get; set; }


        public string AlbumName{ get; set; }
        public string Publised { get; set; }
    }
}
