using HomeLoanManagementSystem.Models;

namespace HomeLoanManagementSystem.Repository.Non_Login
{
    public interface INonLoginRepository
    {
        decimal calculateEmi(EMIModel emi);
        decimal loanEligibilityCalculator(decimal Salary);
    }
}
