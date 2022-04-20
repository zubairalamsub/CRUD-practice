using Entities;
using ICrudeService;
using ICrudReposetory;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudService
{
    public class PersonService:IpersonService
    {
        private readonly IpersonReposetory _personReposetory;

        public PersonService(IpersonReposetory personReposetory)
        {
            _personReposetory = personReposetory;

        }
        public int AddPerson(Person person)
        {
           return _personReposetory.AddPerson(person);
        }
    }
}
