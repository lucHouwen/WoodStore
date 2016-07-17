using DatabaseCommunicator;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Woodstore.Models
{
   public class AccountModel
    {
        [Required(ErrorMessage = "Username is required !")]
        [Index(IsUnique = true)]
        [Display(Name = "your username")]
        [MaxLength(100, ErrorMessage = "Username cannot be longer than 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required !")]
        [Display(Name = "your password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required !")]
        [Display(Name = "MyMail.gmail.com")]
        [EmailAddress(ErrorMessage = "Email is not in correct format !")]
        public string Email { get; set; }

        public bool IsConfirmed { get; set; }

        public string ConfirmationToken { get; set; }

        public string PasswordToken { get; set; }

        public AccountModel()
        { }

        public AccountModel(string username, string unhashedPassword, string email, bool isconfirmed, string confirmationToken)
        {
            Username = username;
            Password = Hasher.Hash(username + unhashedPassword);
            Email = email;
            IsConfirmed = isconfirmed;
            ConfirmationToken = confirmationToken;
        }

        public AccountModel(string username, string unhashedPassword)
        {
            Username = username;
            Password = Hasher.Hash(username + unhashedPassword);
        }

    }
}
