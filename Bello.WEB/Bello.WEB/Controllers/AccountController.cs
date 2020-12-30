using Bello.WEB.Models.Request.Account;
using Bello.WEB.Models.Response.Account;
using Bello.WEB.Ultileties;
using Microsoft.AspNetCore.Mvc;

namespace Bello.WEB.Controllers
{
    public class AccountController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [Route("/account/login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var result = ApiHelper<LoginResult>.HttpPostAsync("account/login", "POST", request);
            return Json(new { data = result });
            
        }
        [HttpPost]
        [Route("/account/register")]
        public JsonResult Register([FromBody] RegisterRequest request)
        {
            var result = ApiHelper<RegisterResult>.HttpPostAsync($"account/register", "POST", request);
            return Json(new { data = result });
        }

        




    }
}
