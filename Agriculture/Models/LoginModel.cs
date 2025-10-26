using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Agriculture.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        public string Username { get; set; } = "superadmin@gmail.com";
        [Required]
        public string Password { get; set; } = "Softech@123";
    }

    public class ApiResponse
    {
        public bool Status { get; set; }
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; } = new object();
    }
    public class LoginResponse
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime NotBefore { get; set; }
        public DateTime Expiration { get; set; }
        public string Role { get; set; }
        public string UserId { get; set; }

    }
    public class RegisterViewModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string FullNameNep { get; set; }
        public string PhoneNo { get; set; }
        public string Role { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public bool? IsActive { get; set; }
        public int WardId { get; set; }
        public string UserName { get; set; }
        public int? FarmerId { get; set; }


    }
}
