using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeLoanManagementSystem.Models;
using HomeLoanManagementSystem.Repository.UserRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace HomeLoanManagementSystem.Controllers
{
    [Authorize(Roles ="User")]
    public class UserController : Controller
    {
        
        private readonly IUserRepository _repo;

        //public UserController()
        //{

        //}
        public UserController(IUserRepository repo)
        {
            _repo = repo;
        }

        // GET: User
        public IActionResult Landing()
        {
            ViewBag.Name = HttpContext.Session.GetString("Name");
            return View();
        }

        // GET: User/Details/?id
        public async Task<IActionResult> Details()
        {
            var id = long.Parse(HttpContext.Session.GetString("Mobile No"));
            var user = await _repo.Profile(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [AllowAnonymous]
        // GET: User/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult Register( User user)
        {
            if (ModelState.IsValid)
            {
                if (_repo.UserRegister(user))
                {
                    return RedirectToAction("Login");
                }
            }
            return View();
        }
        public IActionResult Application()
        {
            ViewBag.Property = new SelectList(new List<string>() { "Commercial", "Residential Apartment","Residential House" });
            ViewBag.Employee = new SelectList(new List<string>() { "Self-Employed","Goverment","Salaried","Other"});
            //ViewBag.Mobile = HttpContext.Session.GetString("Mobile No");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Application(Application application)
        {
            ViewBag.Property = new SelectList(new List<string>() { "Commercial", "Residential Apartment", "Residential House" });
            ViewBag.Employee = new SelectList(new List<string>() { "Self-Employed", "Goverment", "Salaried", "Other" });
            ViewBag.Mobile = HttpContext.Session.GetString("Mobile No");
            application.ApplicationDate = DateTime.Now;
            application.ApplicationStatus = "Pending";
            if (ModelState.IsValid)
            {
                _repo.Application(application);
            }
            return View(application);
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(Login user)
        {
            var result = _repo.UserLogin(user);

            if (ModelState.IsValid)
            {

                if (result != null)
                {
                    HttpContext.Session.SetString("Mobile No", result.Mobile.ToString());
                    HttpContext.Session.SetString("Name", result.Name);
                    

                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.MobilePhone,result.Mobile.ToString()),
                    new Claim(ClaimTypes.Email,result.Email),
                    new Claim(ClaimTypes.Role,"User")

                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal _user = new ClaimsPrincipal(claimsIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, _user, new AuthenticationProperties()
                    {
                        IsPersistent = false,
                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                        AllowRefresh = true
                    }
                        );


                    return RedirectToAction("Landing");
                }
                ModelState.AddModelError(string.Empty, "Invalid username and password");

            }
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string oldpassword, User user)
        {
            Login login = new Login
            {
                Mobile = long.Parse(HttpContext.Session.GetString("Mobile No")),
                Password = oldpassword
            };
            var res = _repo.UserLogin(login);
            if (res == null)
            {
                ViewBag.message = "Old password is wrong";
            }
            else
            {
                var Mob = long.Parse(HttpContext.Session.GetString("Mobile No"));
                // var _user= _repo.Profile(Mob);
                res.Password = user.Password;
                _repo.UpdatePassword(long.Parse(HttpContext.Session.GetString("Mobile No")), res);
            }
            return View();
        }

    }
}
