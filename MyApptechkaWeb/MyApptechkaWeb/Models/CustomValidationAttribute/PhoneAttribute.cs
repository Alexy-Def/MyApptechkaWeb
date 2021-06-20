using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyApptechkaWeb.Models.CustomValidationAttribute
{
    public class PhoneAttribute : ValidationAttribute
    {
        const string validationPattern = @"(?<countryCode>\d{1,3})(?<operatorCode>\d{2})(?<phoneNumber>\d{7})$";
        static Regex regex = new Regex(validationPattern);
        public override string FormatErrorMessage(string name)
        {
            return ErrorMessage ?? $"Неравильный номер";
        }

        public override bool IsValid(object value)
        {
            string phoneString = value as string;
            if (phoneString == null)
                return false;
            return regex.IsMatch(phoneString);
        }
    }
}
