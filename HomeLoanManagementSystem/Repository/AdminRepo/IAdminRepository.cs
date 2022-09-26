using HomeLoanManagementSystem.Models;
using System.Collections.Generic;

namespace HomeLoanManagementSystem.Repository.AdminRepo
{
    public interface IAdminRepository
    {
        Admin Login(Admin admin);

        IEnumerable<User> ViewAllApplications();

        User ViewByAppId(int? id);

        Loan ApproveLoan(int? appId, Application application);

        bool DenyLoan(int? appId, Application application);


    }
}
