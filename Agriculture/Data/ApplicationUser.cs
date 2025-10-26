using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Agriculture.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string FullNameNep { get; set; }
        public int? WardId { get; set; }
        [NotMapped]
        public string Role{ get; set; }
        [NotMapped]
        public string Password { get; set; }
        public bool? IsActive { get; set; }
        public int? FarmerId { get; set; }

    }
}
