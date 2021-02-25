using System.ComponentModel.DataAnnotations;

namespace WebApplication.ViewModels
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Current password")]
        public string CurrentPassword { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="New password")]
        public string NewPassword { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "Password do not match.")]
        public string ConfirmNewPassword { get; set; }
    }
}