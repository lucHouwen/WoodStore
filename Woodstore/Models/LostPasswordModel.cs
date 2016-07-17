using System.ComponentModel.DataAnnotations;

namespace Woodstore.Models
{
    public class LostPasswordModel
    {
        #region Public Properties

        [Required(ErrorMessage = "Email is required !")]
        [Display(Name = "MyMail@gmail.com")]
        [EmailAddress(ErrorMessage = "Email address not in a correct format.")]
        public string Email { get; set; }

        #endregion Public Properties
    }
}