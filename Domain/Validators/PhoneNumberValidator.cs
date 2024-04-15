using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.Entities;
using System.Text.RegularExpressions;
using Domain.Primitives;

namespace Domain.Validators
{
    public class PhoneNumberValidator : AbstractValidator<Person>
    {
        public PhoneNumberValidator() 
        {
            RuleFor(f => f.PhoneNumber).Must(A).WithMessage(f => ValidationMessages.InvalidPhoneNumber(nameof(f.PhoneNumber)));
        }
        private bool A(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\+37377[4-9]\d{6}$");
        }
    }
}
