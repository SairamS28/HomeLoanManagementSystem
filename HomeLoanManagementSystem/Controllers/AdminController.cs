using HomeLoanManagementSystem.Models;
using HomeLoanManagementSystem.Repository.AdminRepo;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace HomeLoanManagementSystem.Controllers
{
    [Authorize(Roles ="Admin")]
    public class AdminController : Controller
    {
        public IAdminRepository _repo;

        public AdminController(IAdminRepository repo)
        {
            _repo = repo;
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string url)
        {
            //ViewBag.url = url;
            return View();
        }
       
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Admin admin)
        {
            if (ModelState.IsValid)
            {

                if (_repo.Login(admin) != null)
                {
                    var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Sid,admin.AdminId.ToString()),
                    new Claim(ClaimTypes.Role,"Admin")

                    };
                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    ClaimsPrincipal user = new ClaimsPrincipal(claimsIdentity);
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, user, new AuthenticationProperties()
                    {

                        IsPersistent = false,
                        //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(60),
                        AllowRefresh = true
                    }
                        );
                    
                    return RedirectToAction("ViewAllApplications");

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
        public IActionResult Index()
        {
           
            return View();
        }

        [Authorize]
        public IActionResult ViewAllApplications()
        {
            ViewBag.ApplicationCount = _repo.GetAllloans().Count();
            ViewBag.ApprovedCount = _repo.GetApprovedApplicationCount();
            ViewBag.DeniedCount = _repo.GetDeniedApplicationCount();
            var result =  _repo.ViewAllApplications();
           return View(result);
        }

        public IActionResult ViewApproved()
        {
            var result = _repo.ViewApproved();
            return View(result);
        }


        public IActionResult ViewDenied()
        {
            var result = _repo.ViewDenied();
            return View(result);
        }




        
        public IActionResult ViewLoanById(int id)
        {
            var application = _repo.ViewByAppId(id);
            if (application != null)
            {
                return View(application);
            }
            return RedirectToAction("ViewAllLoans");
        }

        [HttpPost("{id}")]
        public IActionResult Approve(int id,string Approve,string Deny,string remarks)
        {
            if (Approve == "Approve")
            {
                var application = _repo.ViewByAppId(id);
                application.ApplicationStatus = "Approved";
                Loan loan = new Loan();
                Random random = new Random();

                loan.LoanNo = random.Next();
                loan.LoanStatus = "Approved";
                DateTime date = DateTime.Now;
                DateTime date1 = date.AddDays(6);
                loan.LoanStartDate = date1;
                loan.LoanEndDate = date1.AddYears(Convert.ToInt32(application.Tenure));
                loan.ApprovedAmount = application.Salary * (decimal)0.8 * 80;
                loan.ReqId = application.ApplicationId;
                Loan loanresult=_repo.ApproveLoan(id, application, loan);
                return View(loanresult);
            }
            else
            {
                var application = _repo.ViewByAppId(id);
                application.ApplicationStatus = "Rejected";
                application.Remarks = remarks;
                _repo.DenyLoan(id, application);
                return RedirectToAction("ViewAllLoans");
            }
          
        }

        public IActionResult ViewLoan(int id)
        {
           return View(_repo.GetLoanDetails(id));
        }

        public IActionResult ViewAllLoans()
        {
            return View(_repo.GetAllloans());
        }
       
        
    }
}
