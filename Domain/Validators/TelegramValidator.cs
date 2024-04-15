using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Primitives;
using FluentValidation;

namespace Domain.Validators
{
    public class TelegramValidator : AbstractValidator <Person>
    {
        public TelegramValidator()
        {
            RuleFor(f => f.Telegram)
            .Must(A).WithMessage(f => ValidationMessages.InvalidTelegram(nameof(f.Telegram)));
        }

        private bool A(string telegram)
        {
            return Regex.IsMatch(telegram, @"^@[a-zA-Z0-9]{3,19}$");
        }
    }
}
