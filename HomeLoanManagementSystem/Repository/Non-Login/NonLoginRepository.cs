using HomeLoanManagementSystem.Models;
using System;

namespace HomeLoanManagementSystem.Repository.Non_Login
{
    public class NonLoginRepository:INonLoginRepository
    {
        
     

        public float calculateEmi(EMIModel emi)
        {
            var result = (emi.principal * emi.rate * (1 + emi.rate*emi.tenure) / (1 + emi.rate*emi.tenure- 1));
            return result;
        }

        public double LoanEligibilityCalculator(double Salary)
        {
            double result = new double();
            result = 60 * (0.6 * Salary);
            return result;
        }

        public decimal LoanEligibilityCalculator(decimal Salary)
        {
            throw new NotImplementedException();
        }

        public decimal loanEligibilityCalculator(decimal Salary)
        {
            throw new NotImplementedException();
        }
    }
}
