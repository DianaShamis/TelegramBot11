using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.Interfaces
{
    public interface IPersonRepository : IRepository<Person>
    {
        public List<CustomField<string>> GetCustomFields();
    }
}
