using HomeLoanManagementSystem.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System;
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
        public Loan ApproveLoan(int? appId, Application application, Loan loan)
        {
            try
            {
                _context.Entry(application).State = EntityState.Modified;
            
                _context.Loans.Add(loan);
                _context.SaveChanges();
                return _context.Loans.FirstOrDefault(x=>x.ReqId==application.ApplicationId);
            }catch(Exception e)
            {
                return null;
            }
           
            
            
        }

        public bool DenyLoan(int? appId, Application application)
        {
            try
            {
                _context.Entry(application).State = EntityState.Modified;

                
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int GetApplicationCount()
        {
            return _context.Applications.Count();
        }

        public int GetApprovedApplicationCount()
        {
            return _context.Applications.Where(x=> x.ApplicationStatus == "Approved").Count();
        }

        public int GetDeniedApplicationCount()
        {
            return _context.Applications.Where(x => x.ApplicationStatus == "Rejected").Count();
        }

        public Admin Login(Admin admin)
        {
           
            if(_context.Admins.FirstOrDefault(x => x.AdminId == admin.AdminId && x.Password == admin.Password) != null)
            {
                return admin;
            }
            return null;
        }

        public IEnumerable<Application> ViewAllApplications()
        {
            return _context.Applications.Where(x=>x.ApplicationStatus=="Pending");
        }

        public IEnumerable<Application> ViewApproved()
        {
            return _context.Applications.Include(x => x.user).Where(y => y.ApplicationStatus == "Approved").ToList();
        }


        public IEnumerable<Application> ViewDenied()
        {
            return _context.Applications.Include(x => x.user).Where(y => y.ApplicationStatus == "Rejected" ).ToList();
        }



        public Application ViewByAppId(int? id)
        {
           return _context.Applications.FirstOrDefault(x => x.ApplicationId == id);
        }

        public Loan GetLoanDetails(int id)
        {
           return _context.Loans.FirstOrDefault(x => x.ReqId == id);
        }

        public IEnumerable<Loan> GetAllloans()
        {
            return _context.Loans;
            
        }
    }
}
