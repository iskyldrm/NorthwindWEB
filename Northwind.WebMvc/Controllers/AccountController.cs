using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.WebMvc.Identity;
using Northwind.WebMvc.Models;
using System.Text;

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
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }
            else
            {
                MyUser user = new MyUser();
                user.Email = register.Email;
                user.TCKimlik = register.TcKimlik;

                var result = await userManager.CreateAsync(user, register.Password);
                if (result.Succeeded)
                {
                    var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    StringBuilder mailbuilder = new StringBuilder();
                    mailbuilder.Append("<html>");
                    mailbuilder.Append("<head>");
                    mailbuilder.Append("<meta charset='" + "utf-8'" + " />");
                    mailbuilder.Append("<title> Email Onaylama</title>");
                    mailbuilder.Append("</head>");
                    mailbuilder.Append("<body>");

                    mailbuilder.Append($"<p> Merhaba {user.UserName} </p><br/>");
                    mailbuilder.Append($"Uyelik işlemleri icin aşagidaki linki tiklayin  <br/>");

                    mailbuilder.Append($"<a href='http://localhost:11184/ConfirmEmail/?uid={user.Id}&code={code}'> Onaylayin</a>");

                    mailbuilder.Append("</body>");

                    mailbuilder.Append("</html>");

                    EmailHelper helper = new EmailHelper();

                    bool isSend = helper.SendEmail(user.Email, mailbuilder.ToString());

                    if (isSend)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Mail gonderilemedi");
                        return View(register);
                    }
                }
                else
                {
                    var error = result.Errors.FirstOrDefault();
                    ModelState.AddModelError("", error.Description);
                    return View(register);
                }
            }
        }
    }
}
