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

        
        public void Create(FAQ faq)
        {
            _context.FAQs.Add(faq);
            _context.SaveChanges();
        }

        public List<FAQ> details()
        {
            return _context.FAQs.ToList();
        }

        public List<FAQ> DummyFAQ()
        {
            return _context.FAQs.ToList();
        }
    }
}
