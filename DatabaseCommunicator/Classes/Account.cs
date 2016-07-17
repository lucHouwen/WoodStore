using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseCommunicator.Classes
{
   public class Account
    {
        #region Public Properties

        [Key]
        public int AccountID { get; set; }

        [Required]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string Firstname { get; set; }

        [Required]
        public string Lastname { get; set; }

        [Required]
        public Address Address { get; set; }     

        [Required]
        public string BankAccountNumber { get; set; } // ?????? creditcard , bank , visa , other ??????

        [Index(IsUnique=true)]
        [Required]
        public string Phone { get; set; }


        public bool IsAdmin { get; set; }
        public bool IsConfirmed { get; set; }

        public string ConfirmationToken { get; set; }
        public string PasswordToken { get; set; }

        #endregion Public Properties

        #region Public Constructors

        public Account() { }

        // ADMIN ACCOUNT
        public Account(string username, string password, bool isAdmin)
        {
            Username = username;
            Password = Hasher.Hash(username + password);
            IsAdmin = isAdmin;
        }

        // REGULAR ACCOUNT
        public Account(string username, string password)
        {
            Username = username;
            Password = Hasher.Hash(username + password);
        }

        // REGULAR ACCOUNT
        public Account(string firstname, string lastname, Address address, string phone,string bank, string username, string unhashedPassword,string email,bool isconfirmed, string confirmationToken)
        {
            Firstname = firstname;
            Lastname =lastname;
            Address = address;
            Phone = phone;
            BankAccountNumber = bank;
            Username = username;
            Password = Hasher.Hash(username + unhashedPassword);
            Email = email;          
            IsConfirmed = isconfirmed;
            ConfirmationToken = confirmationToken;
        }

        #endregion Public Constructors
    }
}
