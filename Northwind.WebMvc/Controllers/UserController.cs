using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Northwind.WebMvc.Models;
using System.Security.Claims;

namespace Northwind.WebMvc.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Giris()
        {
            Login login = new Login();
            return View();
        }
        public IActionResult Cikis()
        {
            return View();
        }

        public IActionResult Yasak()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Login user)
        {
            if (user.UserName == "Ali" && user.Password == "4950")
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserName),
                    new Claim(ClaimTypes.Country,"Turkiye")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var principle = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principle, new AuthenticationProperties()
                {
                    IsPersistent = user.RememberMe
                });

                return RedirectToAction("Index", "Shipper");
            }
            else
            {
                return RedirectToAction("Giris", "User");
            }
        }
    }
}
