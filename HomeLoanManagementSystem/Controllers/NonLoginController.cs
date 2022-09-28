using HomeLoanManagementSystem.Models;
using HomeLoanManagementSystem.Repository.Non_Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.Kestrel.Core.Features;
using System;

namespace HomeLoanManagementSystem.Controllers
{
    public class NonLoginController : Controller
    {
        private INonLoginRepository _context;


        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult CalculateEMI()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult CalculateEMI(EMIModel emi)
        {
            float result = new float();
            result = (emi.principal * (emi.rate)/100 * (float)Math.Pow(1 + (emi.rate)/100, emi.tenure)) / (float)(Math.Pow(1 + (emi.rate)/100, emi.tenure) - 1);
            ViewBag.result = result;    
            return View();
        }
        public IActionResult LoanEligibilityCalculator()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoanEligibilityCalculator(double salary)
        {
            double result = new double();
            result = 80 * (0.8 * salary);
            ViewBag.result = result;
            return View();
        }
    }
}
