using HomeLoanManagementSystem.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace HomeLoanManagementSystem.Repository.AdminRepo
{
    public class AdminRepository : IAdminRepository
    {
        public CodeFirstContext _context;

        public AdminRepository(CodeFirstContext context)
        {
            _context = context;
        }
        public Loan ApproveLoan(int? appId, Application application)
        {
            throw new System.NotImplementedException();
        }

        public bool DenyLoan(int? appId, Application application)
        {
            throw new System.NotImplementedException();
        }

        public Admin Login(Admin admin)
        {
           
            if(_context.Admin.FirstOrDefault(x => x.AdminId == admin.AdminId && x.Password == admin.Password) != null)
            {
                return admin;
            }
            return null;
        }

        public IEnumerable<User> ViewAllApplications()
        {
            //return _context.Applications.Find();
            return null;
        }

        public User ViewByAppId(int? id)
        {
            throw new System.NotImplementedException();
        }
    }
}
