using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AgricultureView.Areas.Admin.Models
{
    public class ApplicationFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("पुरा नाम ")]
        public string FullName { get; set; }

        [Required, EmailAddress]
        [DisplayName("इमेल ठेगाना")]

        public string Email { get; set; }

        [Required]
        [DisplayName("मोबाइल नम्बर")]

        public string Phone { get; set; }

        [DisplayName("जन्म मिति ")]

        public string Dob { get; set; }

        [DisplayName("पुरा ठेगाना")]

        public string Address { get; set; }

        [DisplayName("तालिम/कार्यक्रम")]

        [Required]
        public string Program { get; set; }

        [DisplayName("मनपर्ने ब्याच ")]

        [Required]
        public string Batch { get; set; }

        [DisplayName("उच्चतम शैक्षिक योग्यता")]

        public string Qualification { get; set; }
        [DisplayName("शिक्षण संस्थाको नाम")]

        public string Institution { get; set; }
        [DisplayName("सम्बन्धित अनुभव (यदि छ भने)")]

        public string Experience { get; set; }
        [DisplayName("रिज्युमे/CV अपलोड गर्नुहोस् (PDF मात्र) ")]


        [Required]
        public IFormFile Resume { get; set; }
        [DisplayName("Name")]

        public string ResumePath { get; set; }
        [DisplayName("हाम्रोबारे कसरी थाहा पाउनुभयो?")]


        public string Source { get; set; }
        [DisplayName("सन्देश / कभर लेटर (ऐच्छिक)")]

        public string Message { get; set; }
    }
}
