using AgricultureView.Models;
using AgricultureView.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AgricultureView.Controllers
{
    public class AccountController : Controller
    {
        private readonly IGlobalVeriable _globalVeriable;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountController(IGlobalVeriable globalVeriable, IHttpContextAccessor httpContextAccessor)
        {
            _globalVeriable = globalVeriable;
            _httpContextAccessor = httpContextAccessor;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel model)
        {
            try
            {
                var response = await _globalVeriable.PostMethod("login", model);
                if (response.Status)
                {
                    var data = JsonConvert.DeserializeObject<LoginResponse>(response.Data.ToString());
                    _httpContextAccessor.HttpContext.Session.SetString("user", JsonConvert.SerializeObject(data));
                    _globalVeriable.SetToken(data.Token);
                    if (data.Role == "User")
                    {
                        return RedirectToAction("UserView", "Home");

                    }
                    return RedirectToAction("Index", "Home");
                }
                return View(model);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IActionResult> Signout()
        {
            _httpContextAccessor.HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Account");
        }
       
    }
}
