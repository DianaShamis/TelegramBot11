﻿using Domain.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ValueObject
{     /* описать */
    public class FullName : BaseValueObject
    {
        /// <summary>
        /// ToDo. Описать.
        /// </summary>
        public FullName(string firstName, string lastName, string middleName)
        {
            var validator = new FullNameValidator();
            validator.Validate(this);
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? MiddleName { get; set; }

        protected override BaseValueObject DeepClone()
        {
            return new FullName(FirstName, LastName, MiddleName);
        }
    }
}
