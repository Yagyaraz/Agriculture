using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace AgricultureView.Models
{
    public class LoginViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
    public class ApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; } = new object();
    }
    public class CommonTexValViewModel
    {
        public int value { get; set; }
        public string text { get; set; }
    }
    public class CommonTexForStringIdValViewModel
    {
        public string value { get; set; }
        public string text { get; set; }
    }
    public class LoginResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime NotBefore { get; set; }
        public DateTime Expiration { get; set; }
        public string Role { get; set; }
    }
    public class RegisterViewModel
    {
        public string Id { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public string FullName { get; set; }
        public string FullNameNep { get; set; }
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Invalid Phone number")]
        [Display(Name = "Phone Number")]
        public string PhoneNo { get; set; }
        public string Role { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        public bool? IsActive { get; set; }
        public int WardId { get; set; }
        public int? FarmerId { get; set; }
    }
}
