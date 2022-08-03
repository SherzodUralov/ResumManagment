using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ResumManagment.ViewModel
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Remote(action: "IsEmailInUse", controller: "Account")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name ="Confirm password")]
        [Compare("Password", ErrorMessage ="password and ConfirmPassword do not much.")]
        public string ConfirmPassword { get; set; }
        public string City { get; set; }
    }
}
