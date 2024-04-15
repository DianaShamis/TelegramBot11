using Domain.Primitives;
using Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Dtos
{
    public class PersonGetByIdResponse
    {
        public FullName FullName { get; private set; }
        public DateTime Birthday { get; private set; }
        public int Age => DateTime.Now.Year - Birthday.Year;
        public Gender Gender { get; private set; }
        public string PhoneNumber { get; private set; }
        public string Telegram { get; private set; }

    }
}
