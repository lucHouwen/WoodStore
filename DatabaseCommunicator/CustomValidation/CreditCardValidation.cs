using System;
using System.ComponentModel.DataAnnotations;

namespace DatabaseCommunicator
{
   public class CreditCardValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (CreditcardChecker.IsValidNumber(value.ToString()))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("Creditcard number or format is not valid.");
        }
    }
}
