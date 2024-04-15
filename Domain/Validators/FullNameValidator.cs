using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.ValueObject;
using Domain.Primitives;
using System.Text.RegularExpressions;

namespace Domain.Validators
{
    public class FullNameValidator : AbstractValidator<FullName>
    {
        public FullNameValidator() 
        {
            RuleFor(f => f.FirstName)
                .NotNull().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.FirstName)))
                .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.FirstName)))
                .Must(A).WithMessage(f => ValidationMessages.RussianOrEnglish(nameof(f.FirstName)));
            RuleFor(f => f.LastName)
                .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.LastName)))
                .Must(A) .WithMessage(f => ValidationMessages.RussianOrEnglish(nameof(f.LastName)))
                .NotNull().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.LastName)));
            RuleFor(f => f.MiddleName)
               .NotEmpty().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.MiddleName)))
               .Must(A).WithMessage(f => ValidationMessages.RussianOrEnglish(nameof(f.MiddleName)))
               .NotNull().WithMessage(f => ValidationMessages.NullOrEmpty(nameof(f.MiddleName)));
        }
        private static bool A(string name)
        {
            return Regex.IsMatch(name, @"^[a-zA-Zа-яА-Я]+$");
        }
    }
}
