using System.ComponentModel.DataAnnotations;

namespace AgricultureView.Areas.Admin.Models
{
    public class ApplicationFormViewModel
    {
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string  Dob { get; set; }

        public string Address { get; set; }

        [Required]
        public string Program { get; set; }

        [Required]
        public string Batch { get; set; }

        public string Qualification { get; set; }
        public string Institution { get; set; }
        public string Experience { get; set; }

        [Required]
        public IFormFile Resume { get; set; }
        public string ResumePath {  get; set; }

        public string Source { get; set; }
        public string Message { get; set; }
    }
}
