using HomeLoanManagementSystem.Models;
using HomeLoanManagementSystem.Repository.FAQRepo;
using HomeLoanManagementSystem.Repository.Non_Login;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeLoanManagementSystem.Controllers
{
    public class FAQController : Controller
    {
        private IFAQRepository _Repo;

        public FAQController(IFAQRepository Repo)
        {
            _Repo = Repo;
        }


        // GET: FAQController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View(_Repo.details());
        //}

        public ActionResult DummyFAQ(int id)
        {
            return View(_Repo.DummyFAQ());
        }
     



    }
}
