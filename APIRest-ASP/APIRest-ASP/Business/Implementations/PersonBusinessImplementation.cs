    using APIRest_ASP.Model;
using APIRest_ASP.Model.Context;
using APIRest_ASP.Repository;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;

namespace APIRest_ASP.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

        private readonly IPersonRepository _repository;

        public PersonBusinessImplementation(IPersonRepository repository)
        {
            _repository = repository;
        }

        // Method responsible for returning all people,
        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        // Method responsible for returning one person by ID
        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        // Method responsible to crete one new person
        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        // Method responsible for updating one person
        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}