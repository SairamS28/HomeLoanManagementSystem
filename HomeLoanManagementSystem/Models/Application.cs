using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeLoanManagementSystem.Models
{
    public class Application
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ApplicationId { get; set; }
        [ForeignKey("user")]
        public long Mobile{ get; set; }
        [Required]
        public string PropertyType { get; set; }
        [Required]
        [Column(TypeName = "Decimal(10,2)")]
        public decimal PropertyCost { get; set; }
        [Required]
        [Column(TypeName = "Decimal(10,2)")]
        public decimal Salary { get; set; }
        [Required]
        public string EmployeeType { get; set; }
        [Required]
        public string PropertyAddress {get; set; }
        [Required]
        [Column(TypeName ="Decimal(10,2)")]
        public decimal LoanAmount { get; set; }
        [Required]
        [Column(TypeName = "Decimal(10,2)")]
        public decimal EMI { get; set; }
        [Required]
        public float Tenure { get; set; }

        public DateTime ApplicationDate { get; set; }
        
        public string ApplicationStatus { get; set; }
        [Required]
        public string PermanentAddress { get; set; }
        [Required]
        public long AadharNo { get; set; }
        [Required]
        public float RateOfInterest { get; set; }

        public string Remarks { get; set; }
        
        public virtual User user { get; set; }
        public ICollection<Loan> loans { get; set; }
       
    }
}
