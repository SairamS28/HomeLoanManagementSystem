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
        //public IActionResult Eligibility(sal)
        //{
        //    public int loan_amt;
        //    loan_amt=
        //    return View();
        //}

        public IActionResult CalculateEMI()
        {
            
            return View();
        }
        public IActionResult CalculateEMI(EMIModel emi)
        {
            float result = new float();
            result = (emi.principal * emi.rate * (float)Math.Pow(1 + emi.rate, emi.tenure)) / (float)(Math.Pow(1 + emi.rate, emi.tenure) - 1);

            return View();
        }
    }
}
