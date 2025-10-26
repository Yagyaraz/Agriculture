using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Agriculture.Data
{
    public class Playlist
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublised { get; set; }


        public int CreatedWardId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class VideoGallery
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int PlaylistId { get; set; }
        public bool IsPublised { get; set; }
        public string FilePath { get; set; }
        public string Description { get; set; }
        public string YoutubeURL { get; set; }

        public int CreatedWardId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey(nameof(PlaylistId))]
        public Playlist Playlist { get; set; }
    }
}
