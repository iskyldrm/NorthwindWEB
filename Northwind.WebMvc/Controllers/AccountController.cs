using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.WebMvc.Identity;
using Northwind.WebMvc.Models;

namespace Northwind.WebMvc.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyUser> userManager;
        private readonly SignInManager<MyUser> signInManager;

        public AccountController(UserManager<MyUser> userManager, SignInManager<MyUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            else
            {
                var user = await userManager.FindByEmailAsync(login.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Girilen bilgiler hatalı");
                    return View(login);
                }
                if (!await userManager.IsEmailConfirmedAsync(user))
                {
                    ModelState.AddModelError("", "Mail adresi doğrulanmalı");
                    return View(login);
                }
                var result = await signInManager.PasswordSignInAsync(user, login.Password, login.RemeberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home", new { area = "Admin" });
                }
                else
                {
                    ModelState.AddModelError("", "Mail adresi doğrulanmalı");
                    return View();
                }

            }

        }

        public IActionResult Register()
        {
            RegisterModel registerModel = new RegisterModel();
            return View(registerModel);
        }
    }
}
