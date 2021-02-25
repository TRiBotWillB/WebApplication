using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class AddPasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}