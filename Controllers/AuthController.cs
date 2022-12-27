using dog_club.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace dog_club.Controllers
{
    public class AuthController : Controller
    {
        private testdbContext db;
        public AuthController(testdbContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        //[ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Login(User model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(user => user.userName == model.userName && user.password == model.password);
                if (user != null)
                {
                    await Authenticate(user); // аутентификация

                    return RedirectToAction("Profile", "Lk");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
            }
            return View(model);
        }

        private async Task Authenticate(User user)
        {
            Role role = db.Roles.Where(role => role.id == user.roleId).FirstOrDefault();
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.userName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, role.isAdmin ? "admin" : "user")
            };
            
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
            HttpContext.Response.Cookies.Append("isAdmin", role.isAdmin.ToString());
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            HttpContext.Response.Cookies.Delete("isAdmin");
            return RedirectToAction("Login", "Auth");
            
        }
    }
}
