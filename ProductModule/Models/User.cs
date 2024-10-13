using System.ComponentModel.DataAnnotations;

namespace ProductModule.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string Email { get; set; }
        [Required]
        //[RegularExpression(@"[a-zA-Z0-9]")]
        [StringLength(maximumLength: 20, MinimumLength = 8, ErrorMessage = "Password should be atlest 8 characters")]

        public string PasswordHash { get; set; }
        [Required(ErrorMessage = "Confirm password")]
        [Compare("Password", ErrorMessage = "Password Does not match")]
        public string ConfirmPassword { get; set; }
        public string Role { get; set; }
      
      
    }
}
