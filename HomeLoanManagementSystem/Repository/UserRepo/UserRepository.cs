using HomeLoanManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLoanManagementSystem.Repository.UserRepo
{
    public class UserRepository:IUserRepository
    {
        CodeFirstContext _context;
        public UserRepository(CodeFirstContext context)
        {
            _context = context;
        }

        public void Application(Application application)
        {
            _context.Applications.Add(application);
            _context.SaveChanges();
        }

        public User UserLogin(Login user)
        {
            return _context.Users.FirstOrDefault(x => x.Mobile == user.Mobile && x.Password == user.Password);
        }

        public bool UserRegister(User user)
        {
            var result =  _context.Users.FirstOrDefault(emp => emp.Mobile== user.Mobile);
            if (result == null)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }
        public async Task<User> Profile(long? id)
        {

            var user = await _context.Users
                .FirstOrDefaultAsync(m => m.Mobile == id);
            return user;
        }

        public void UpdatePassword(long? id, User user)
        {
            try
            {
                _context.Entry(user).State = EntityState.Modified;
                // _context.Employee.Update(employee);
                _context.SaveChanges();
                
            }
            catch(SystemException e)
            {
                throw e;
            }
        }
    }
}
