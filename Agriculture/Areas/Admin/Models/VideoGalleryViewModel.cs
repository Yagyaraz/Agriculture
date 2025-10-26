namespace Agriculture.Areas.Admin.Models
{
    public class PlaylistViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublised { get; set; }
        public string Publised { get; set; }
    }
    public class VideoGalleryViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PlaylistId { get; set; }
        public bool IsPublised { get; set; }
        public string FilePath { get; set; }
        public IFormFile FilePoto { get; set; }
        public string YoutubeURL { get; set; }
        public string Description { get; set; }



        public string PlaylistName { get; set; }
        public string Publised { get; set; }
    }
}
