using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeLoanManagementSystem.Models
{
    public class Loan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LoanNo { get; set; }
        [ForeignKey("application")]
        public int ReqId { get; set; }
        public string LoanStatus { get; set; }
        [Required]
        [Column(TypeName = "Decimal(10,2)")]
        public decimal ApprovedAmount { get; set; }
        [Required]
        public DateTime LoanStartDate { get; set; }
        [Required]
        public DateTime LoanEndDate { get; set; }


        public virtual Application application { get; set; }
    }
}
