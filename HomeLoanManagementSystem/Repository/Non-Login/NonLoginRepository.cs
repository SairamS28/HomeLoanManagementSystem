using HomeLoanManagementSystem.Models;
using System;

namespace HomeLoanManagementSystem.Repository.Non_Login
{
    public class NonLoginRepository:INonLoginRepository
    {
        
        public float CalculateEmi(EMIModel emi)
        {
            float result = new float();
            result = (emi.principal * emi.rate * (float)Math.Pow(1 + emi.rate, emi.tenure)) / (float)(Math.Pow(1 + emi.rate, emi.tenure) - 1);
            return result;

        }

        public decimal calculateEmi(EMIModel emi)
        {
            throw new NotImplementedException();
        }

        public decimal loanEligibilityCalculator(decimal Salary)
        {
            throw new System.NotImplementedException();
        }
    }
}
