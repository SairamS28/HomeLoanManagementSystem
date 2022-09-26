using HomeLoanManagementSystem.Models;
using System.Threading.Tasks;

namespace HomeLoanManagementSystem.Repository.UserRepo
{
    public interface IUserRepository
    {
        public Task<bool> UserRegister(User user);
        public User UserLogin(Login user);
        public void Application(Application application);
        public  Task<User> Profile(long? id);
    }
}
