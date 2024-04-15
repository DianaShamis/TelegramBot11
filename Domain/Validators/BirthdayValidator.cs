using Domain.Primitives;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.Entities;

namespace Domain.Validators
{
    public class BirthdayValidator : AbstractValidator <Person>
    {
        public BirthdayValidator()
        {
            RuleFor(f => f.Birthday)
             .Must(A).WithMessage(f => ValidationMessages.InvalidBirthday(nameof(f.Birthday)));
        }

        private bool A(DateTime birthDay)
        {
            return DateTime.Now.Year - birthDay.Year <= 150 && birthDay > DateTime.Now;
        }
    }
}
