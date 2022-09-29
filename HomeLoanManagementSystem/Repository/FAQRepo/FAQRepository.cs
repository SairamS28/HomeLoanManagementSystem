using HomeLoanManagementSystem.Models;
using System.Collections.Generic;
using System.Linq;

namespace HomeLoanManagementSystem.Repository.FAQRepo
{
    public class FAQRepository:IFAQRepository
    {
        private CodeFirstContext _context;

        public FAQRepository(CodeFirstContext context)
        {
            _context = context;
        }

        //public List<FAQ> details()
        //{
        //    throw new System.NotImplementedException();
        //}

        public List<FAQ> DummyFAQ()
        {
            return _context.FAQs.ToList();
        }
    }
}
