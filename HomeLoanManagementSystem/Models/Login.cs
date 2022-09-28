using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeLoanManagementSystem.Models
{
    public class Login
    {
       
        [Required(ErrorMessage="Please Enter Registered mobile number")]
        public long Mobile { get; set; }
      
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
