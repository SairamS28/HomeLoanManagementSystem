using HomeLoanManagementSystem.Models;
using System.Linq;

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
            return _context.Users.FirstOrDefault(x => x.Email == user.EmailAddress && x.Password == user.Password);
        }

        public bool UserRegister(User user)
        {
            var result = _context.Users.FirstOrDefault(emp => emp.Email == user.Email);
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
    }
}
