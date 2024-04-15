using Application.Dtos;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces;
using Application.Dtos;
using AutoMapper;

namespace Application.Services
{
    internal class PersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public PersonGetByIdResponse GetById(Guid id)
        {
            var person = _personRepository.GetByID(id);
            if (person == null)
            {
                throw new Exception($"Пользователь: {id} не найден.");
            }

            var response = _mapper.Map<PersonGetByIdResponse>(person);
            return response;
        }
    }
}




