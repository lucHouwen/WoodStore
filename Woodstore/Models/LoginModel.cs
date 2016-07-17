using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Woodstore.Models
{
   public class LoginModel
    {
        [Required(ErrorMessage = "Username is required !")]
        [Display(Name = "Your username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required !")]
        [Display(Name = "Your password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool RememberMe { get; set; }
    }
}
