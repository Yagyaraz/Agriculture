using Agriculture.Data;
using Agriculture.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Agriculture.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly AgricultureDbContext context;
        private readonly IConfiguration configuration;

        public AuthenticateController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AgricultureDbContext context, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.context = context;
            this.configuration = configuration;
        }
        [AllowAnonymous]
        [HttpGet("/")] public IActionResult Test() => Ok("Welcome to Agriculture Api");

        [AllowAnonymous]
        [HttpGet("api/status")]
        public IActionResult Status()
        {
            return Ok(new ApiResponse { Status = true, Message = "Api is Running" });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {

            var result = await signInManager.PasswordSignInAsync(model.Username, model.Password, false, false);
            if (result.Succeeded)
            {
                var user = await userManager.FindByNameAsync(model.Username);

                var userRoles = await userManager.GetRolesAsync(user);
                var role = userRoles.FirstOrDefault();
                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Role, role),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                var token = new JwtSecurityToken(
                    issuer: configuration["JsonWebTokenKeys:ValidIssuer"],
                    audience: configuration["JsonWebTokenKeys:ValidAudience"],
                    claims: authClaims,
                    notBefore: DateTime.UtcNow,
                    //  expires: DateTime.UtcNow.AddMinutes(1),
                    expires: DateTime.UtcNow.AddDays(1),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JsonWebTokenKeys:IssuerSigningKey"])), SecurityAlgorithms.HmacSha256));

                var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
                Response.Cookies.Append("jwt", jwtToken, new CookieOptions() { HttpOnly = true, SameSite = SameSiteMode.None });

                var response = new ApiResponse
                {
                    Status = true,
                    Message = "After Login Informanation !",
                    Data = new LoginResponse
                    {
                        Name = user.FullName,
                        Role = role,
                        Token = jwtToken,
                        NotBefore = token.ValidFrom,
                        Expiration = token.ValidTo,
                        //UserId = user.Id,
                    }
                };
                return Ok(response);
            }
            if (result.IsLockedOut)
            {
                return Ok(new ApiResponse() { Status = false, Message = "User account Deactivated !" });
            }
            return Ok(new ApiResponse() { Status = false, Message = "Sorry! invalid credential.." });
        }

    }
}
