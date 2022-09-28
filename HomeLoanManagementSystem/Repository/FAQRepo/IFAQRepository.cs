using HomeLoanManagementSystem.Models;
using System.Collections.Generic;

namespace HomeLoanManagementSystem.Repository.FAQRepo
{
    public interface IFAQRepository
    {
        List<FAQ> details();
        void Create(FAQ faq);

        List<FAQ> DummyFAQ();

    }
}
