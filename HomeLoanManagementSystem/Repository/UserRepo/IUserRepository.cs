using HomeLoanManagementSystem.Models;
namespace HomeLoanManagementSystem.Repository.UserRepo
{
    public interface IUserRepository
    {
        public bool UserRegister(User user);
        public User UserLogin(Login user);
        public void Application(Application application);
    }
}
