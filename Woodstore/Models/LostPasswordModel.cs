using System.ComponentModel.DataAnnotations;

namespace Woodstore.Models
{
    public class LostPasswordModel
    {
        #region Public Properties

        [Required(ErrorMessage = "Email is required !")]
        [Display(Name = "Email :")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        [EmailAddress(ErrorMessage = "Email address not in a correct format.")]
        public string Email { get; set; }

        #endregion Public Properties
    }
}