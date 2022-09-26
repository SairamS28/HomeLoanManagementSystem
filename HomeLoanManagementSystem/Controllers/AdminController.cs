using Microsoft.AspNetCore.Mvc;

namespace HomeLoanManagementSystem.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ViewAllLoans()
        {
           return View();
        }
    }
}
