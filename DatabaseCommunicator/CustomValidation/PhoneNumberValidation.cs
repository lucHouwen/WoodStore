using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseCommunicator.CustomValidation
{
   public class PhoneNumberValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {   // 9 nrs == fixed tel     10 nrs == mobile

            /* POSSIBLE INPUTS 
            012-345678
            012 34 56 78 
            012 345 678
            +32 12 34 56 78
            +0032 12 34 56 78
            0032 12 34 56 78
            (32) 123456789
            (0032) 123456789
            (+32) 123456789
            (+0032) 123456789
            
            possible chars to remove =>  '-' , '/' , ' ' , '+' , '(' , ')' , '0032' , '32' ..... 
            
            OR JUST SHOW EXAMPLE FOR A CORRECT NUMBER =>  0123456789 || 0478234567    => DONE ! 
            */
            long validPhone;   
            if (value.ToString().Length > 8 && value.ToString().Length < 11 && long.TryParse(value.ToString(), out validPhone))
            {
                long phone;    
                if(long.TryParse(value.ToString(),out phone))
                {
                    return ValidationResult.Success;
                }
                else { return new ValidationResult("Numbers only please."); }
            }
            return new ValidationResult("Phone number format is not valid.");
        }
    }
}
