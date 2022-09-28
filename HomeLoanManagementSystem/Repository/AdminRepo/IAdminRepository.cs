using HomeLoanManagementSystem.Models;
using System.Collections.Generic;

namespace HomeLoanManagementSystem.Repository.AdminRepo
{
    public interface IAdminRepository
    {
        Admin Login(Admin admin);

        IEnumerable<Application> ViewAllApplications();

        IEnumerable<Application> ViewApproved();

        IEnumerable<Application> ViewDenied();

        Application ViewByAppId(int? id);

        Loan ApproveLoan(int? appId, Application application, Loan loan);

        bool DenyLoan(int? appId, Application application);

        int GetApplicationCount();

        int GetApprovedApplicationCount();

        int GetDeniedApplicationCount();

        Loan GetLoanDetails(int id);

    }
}
