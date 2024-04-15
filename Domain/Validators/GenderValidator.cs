using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Domain.Entities;
using Domain.ValueObject;
using Domain.Primitives;

namespace Domain.Validators 
{
    public class GenderValidator : AbstractValidator<Person>
    {
        public GenderValidator()
        {
            RuleFor(f => f.Gender)
                .NotEmpty().WithMessage(f => ValidationMessages.UndefinedGender(nameof(f.Gender)));
        }
    }
}
