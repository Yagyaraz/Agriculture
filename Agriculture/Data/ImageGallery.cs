using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Agriculture.Data
{
    public class Album
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsPublised { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int CreatedWardId { get; set; }

    }
    public class ImageGallery
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public int AlbumId { get; set; }
        public bool IsPublised { get; set; }
        public string FilePath { get; set; }
        public int CreatedWardId { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        [ForeignKey(nameof(AlbumId))]
        public Album Album { get; set; }
    }
}
