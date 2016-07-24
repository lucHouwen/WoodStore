using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.CustomValidation
{
    public class UsernameChecker : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!DataBaseHandler.UsernameExist(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Username is taken.");
        }
    }
}

