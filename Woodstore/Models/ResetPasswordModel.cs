using System.ComponentModel.DataAnnotations;

namespace Woodstore.Models
{
    public class ResetPasswordModel
    {
        #region Public Properties

        public string PasswordToken { get; set; }

        [Required(ErrorMessage = "Password is required !")]
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required !")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not matching , Try again!")]
        public string RepeatPassword { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public ResetPasswordModel()
        {
        }

        public ResetPasswordModel(string id)
        {
            PasswordToken = id;
        }

        #endregion Public Constructors
    }
}