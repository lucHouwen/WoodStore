using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.CustomValidation
{
    public class EmailChecker: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!DataBaseHandler.EmailExist(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Email address is already in use.");
        }
    }
}
