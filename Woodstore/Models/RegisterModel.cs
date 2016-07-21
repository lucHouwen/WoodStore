using DatabaseCommunicator.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Woodstore.Models
{
    public class RegisterModel
    {
        #region Public Properties

        [Required(ErrorMessage = "Firstname is required !")]
        [Display(Name = "Firstname")]
        [MinLength(1, ErrorMessage = "firstname must be atleast 1 characters long")]
        [MaxLength(50, ErrorMessage = "firstname cannot be longer than 50 characters")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Lastname is required !")]
        [Display(Name = "Lastname")]
        [MinLength(1, ErrorMessage = "lastname must be atleast 1 characters long")]
        [MaxLength(50, ErrorMessage = "lastname cannot be longer than 50 characters")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Street name is required !")]
        [Display(Name = "Street")]
        [MinLength(1, ErrorMessage = "firstname must be atleast 1 characters long")]
        [MaxLength(80, ErrorMessage = "firstname cannot be longer than 80 characters")]
        public string Street { get; set; }

        [Required(ErrorMessage = "House Nr is required !")]
        [Display(Name = "Nr")]
        //[MinLength(1, ErrorMessage = "house number must be atleast 1 characters long")]
        //[MaxLength(10, ErrorMessage = "house number cannot be longer than 10 characters")]
        public int Number { get; set; }

        [Display(Name = "Box")]
        //[MinLength(1, ErrorMessage = "box number must be atleast 1 characters long")]
        //[MaxLength(10, ErrorMessage = "box number cannot be longer than 10 characters")]
        public string Box { get; set; }

        [Required(ErrorMessage = "Zipcode is required !")]
        [Display(Name = "Zipcode")]
        //[MinLength(4, ErrorMessage = "Zipcode / postal number must be atleast 1 characters long")]
        //[MaxLength(4, ErrorMessage = "Zipcode / postal number cannot be longer than 10 characters")]
        public int Zipcode { get; set; }

        [Required(ErrorMessage = "City name is required !")]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required(ErrorMessage = "Country name is required !")]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Visa or Bankcontact is required !")]
        [Display(Name = "Bank (Visa or Bankcontact)")]
        [DataType(DataType.Password)]
        public string BankAccountNumber { get; set; } 

        [Required(ErrorMessage = "Telephone is required !")]
        [Index(IsUnique = true)]
        [Display(Name = "Telephone")]
        public string Phone { get; set; }
      

        [Required(ErrorMessage = "Username is required !")]
        [Display(Name = "Username")]
        [MinLength(3, ErrorMessage = "Username must be atleast 3 characters long")]
        [MaxLength(50, ErrorMessage = "Username cannot be longer than 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required !")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email is not in a correct format !")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required !")]
        [Display(Name = "Password")]
        [MinLength(3, ErrorMessage = "Password must be atleast 3 characters long")]
        [MaxLength(50, ErrorMessage = "Password cannot be longer than 50 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password is required !")]
        [Display(Name = "¨Repeat password")]
        [MinLength(3, ErrorMessage = "Password must be atleast 3 characters long")]
        [MaxLength(50, ErrorMessage = "Password cannot be longer than 50 characters")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords not matching , Try again!")]
        public string RepeatPassword { get; set; }

        #endregion Public Properties
    }
}