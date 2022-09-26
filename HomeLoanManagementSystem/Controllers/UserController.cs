using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HomeLoanManagementSystem.Models;
using HomeLoanManagementSystem.Repository.UserRepo;

namespace HomeLoanManagementSystem.Controllers
{
    public class UserController : Controller
    {
        private readonly CodeFirstContext _context;
        private readonly IUserRepository _repo;

        public UserController(CodeFirstContext context)
        {
            _context = context;
        }

        // GET: User
        public IActionResult Landing()
        {
            return View();
        }

        // GET: User/Details/?id
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _repo.Profile(id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }
        
        // GET: User/Register
        public IActionResult Register()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("Mobile,Email,DateOfBirth,Address,Name,Password")] User user)
        {
            if (ModelState.IsValid)
            {
               await _repo.UserRegister(user);
            }
            return View(user);
        }
        public IActionResult Application()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Application(Application application)
        {
            if (ModelState.IsValid)
            {
                _repo.Application(application);
            }
            return View(application);
        }
    }
}
