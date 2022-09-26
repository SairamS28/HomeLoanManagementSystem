using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeLoanManagementSystem.Models
{
    public class User
    {
        [Key]
        [RegularExpression(@"[6-9]{1}[0-9]{9}", ErrorMessage = "Invalid Phone No")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long Mobile { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+)*@[a-zA-Z0-9]+(?:\.[a-zA-Z0-9]+)*$", ErrorMessage = "Invalid Email.")]
        public string Email { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Name { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"([A-Z]{1}[a-zA-Z0-9]{3,})",ErrorMessage ="Password Should have first letter captial and no special character")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [RegularExpression(@"([A-Z]{1}[a-zA-Z0-9]{3,})",ErrorMessage ="Password Should have first letter captial and no special character")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [NotMapped]
        public string ConfirmPassword { get; set; }

        public ICollection<Application> application { get; set; }

    }
}
