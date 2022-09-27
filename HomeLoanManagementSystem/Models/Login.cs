using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeLoanManagementSystem.Models
{
    public class Login
    {
        [RegularExpression(@"[6-9]{1}[0-9]{9}", ErrorMessage = "Invalid Phone No")]
        [Required(ErrorMessage="Please Enter Registered mobile number")]
        public long Mobile { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"([A-Z]{1}[a-zA-Z0-9]{3,})", ErrorMessage = "Password Should have first letter captial and no special character")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
