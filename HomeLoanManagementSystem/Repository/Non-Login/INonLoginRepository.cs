using HomeLoanManagementSystem.Models;

namespace HomeLoanManagementSystem.Repository.Non_Login
{
    public interface INonLoginRepository
    {
        float calculateEmi(EMIModel emi);
        decimal loanEligibilityCalculator(decimal Salary);
    }
}
