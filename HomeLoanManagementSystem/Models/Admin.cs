using System.ComponentModel.DataAnnotations;

namespace HomeLoanManagementSystem.Models
{
    public class Admin
    {
        [Key]
        [Required]
        public int AdminId { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
