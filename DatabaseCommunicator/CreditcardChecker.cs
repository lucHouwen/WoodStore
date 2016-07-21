using System;
using System.Text.RegularExpressions;

namespace DatabaseCommunicator
{
   public class CreditcardChecker
    {
        private const string cardRegex = "^(?:(?<Visa>4\\d{3})|(?<MasterCard>5[1-5]\\d{2})|(?<Discover>6011)|(?<DinersClub>(?:3[68]\\d{2})|(?:30[0-5]\\d))|(?<Amex>3[47]\\d{2}))([ -]?)(?(DinersClub)(?:\\d{6}\\1\\d{4})|(?(Amex)(?:\\d{6}\\1\\d{5})|(?:\\d{4}\\1\\d{4}\\1\\d{4})))$";
        private static string firstTen; // first 10 nrs
        private static long validnumber; // complete card nr
        private static int lastTwo; // last 2 nrs

        public static bool IsValidNumber(string cardNum)
        {
            Regex cardTest = new Regex(cardRegex);

            //Determine the card type based on the number
            CreditCardType? cardType = GetCardTypeFromNumber(cardNum);

            if (!(cardType == CreditCardType.Maestro))
            {
                //Call the base version of IsValidNumber and pass the number and card type
                if (IsValidNumber(cardNum, cardType))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }
        }

        public static bool IsValidNumber(string cardNum, CreditCardType? cardType)
        {
            //Create new instance of Regex comparer with our 
            //credit card regex pattern
            Regex cardTest = new Regex(cardRegex);

            //Make sure the supplied number matches the supplied
            //card type
            if (cardTest.Match(cardNum).Groups[cardType.ToString()].Success)
            {
                //If the card type matches the number, then run it
                //through Luhn's test to make sure the number appears correct
                if (PassesLuhnTest(cardNum))
                    return true;
                else
                    //The card fails Luhn's test
                    return false;
            }
            else
                //The card number does not match the card type
                return false;
        }

        public static CreditCardType? GetCardTypeFromNumber(string cardNum)
        {
            //Create new instance of Regex comparer with our
            //credit card regex pattern
            Regex cardTest = new Regex(cardRegex);

            //Compare the supplied card number with the regex
            //pattern and get reference regex named groups
            GroupCollection gc = cardTest.Match(cardNum).Groups;

            //Compare each card type to the named groups to 
            //determine which card type the number matches
            if (gc[CreditCardType.Amex.ToString()].Success)
            {
                return CreditCardType.Amex;
            }
            else if (gc[CreditCardType.MasterCard.ToString()].Success)
            {
                return CreditCardType.MasterCard;
            }
            else if (gc[CreditCardType.Visa.ToString()].Success)
            {
                return CreditCardType.Visa;
            }
            else if(PassesModuloTest(cardNum))
            {
                return CreditCardType.Maestro;
            }
            else
            {
                //Card type is not supported by our system, return null
                //(You can modify this code to support more (or less)
                // card types as it pertains to your application)
                return null;
            }
        }

        public static string GetCardTestNumber(CreditCardType cardType)
        {
            //According to PayPal, the valid test numbers that should be used
            //for testing card transactions are:

            //Credit Card Type              Credit Card Number

            //American Express              378282246310005
            //American Express              371449635398431
            //American Express Corporate    378734493671000             
            //MasterCard                    5555555555554444
            //MasterCard                    5105105105105100
            //Visa                          4111111111111111
            //Visa                          4012888888881881

            //Src: https://www.paypal.com/en_US/vhelp/paypalmanager_help/credit_card_numbers.htm
            //Credit: Scott Dorman, http://www.geekswithblogs.net/sdorman

            //Return bogus CC number that passes Luhn and format tests
            switch (cardType)
            {
                case CreditCardType.Amex:
                    return "3782 822463 10005";               
                case CreditCardType.MasterCard:
                    return "5105 1051 0510 5100";
                case CreditCardType.Visa:
                    return "4111 1111 1111 1111";
                default:
                    return null;
            }
        }

        public static bool PassesLuhnTest(string cardNumber)
        {
            //Clean the card number - remove dashes and spaces
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");

            //Convert card number into digits array
            int[] digits = new int[cardNumber.Length];
            for (int len = 0; len < cardNumber.Length; len++)
            {
                digits[len] = int.Parse(cardNumber.Substring(len, 1));
            }
                      
            int sum = 0;
            bool alt = false;
            for (int i = digits.Length - 1; i >= 0; i--)
            {
                int curDigit = digits[i];
                if (alt)
                {
                    curDigit *= 2;
                    if (curDigit > 9)
                    {
                        curDigit -= 9;
                    }
                }
                sum += curDigit;
                alt = !alt;
            }

            //If Mod 10 equals 0, the number is good and this will return true
            return sum % 10 == 0;
        }

        public static bool PassesModuloTest(string cardNumber)
        {
            /* rest of division from first 10 nrs %97 has to be equal to last 2 nrs. */  
                           
            if (long.TryParse(cardNumber, out validnumber))
            {
                firstTen = cardNumber.Substring(0, 10);
                lastTwo = Convert.ToInt32(cardNumber.Substring(10, 2));

                if(Convert.ToInt32(firstTen)% 97 == lastTwo)
                { return true; }

                else { return false; }             
            }
            else { return false; }           
        }
    }

    public enum CreditCardType
    {
        Visa,
        MasterCard,
        Amex,
        Maestro
    }
}

