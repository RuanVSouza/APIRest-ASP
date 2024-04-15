using APIRest_ASP.Data.Converter.Implementation;
using APIRest_ASP.Data.VO;
using APIRest_ASP.Model;
using APIRest_ASP.Repository.Generic;

namespace APIRest_ASP.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {

        private readonly IRepository<Person> _repository;
        private readonly PersonConverter _converter;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
            _converter = new PersonConverter();
        }

        // Method responsible for returning all people,
        public List<PersonVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
            
        }

        // Method responsible for returning one person by ID
        public PersonVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        // Method responsible to crete one new person
        public PersonVO Create(PersonVO person)
        {
            var personEntitiy = _converter.Parse(person);
            personEntitiy = _repository.Create(personEntitiy);
            return _converter.Parse(personEntitiy);
        }

        // Method responsible for updating one person
        public PersonVO Update(PersonVO person)
        {
            var personEntitiy = _converter.Parse(person);
            personEntitiy = _repository.Update(personEntitiy);
            return _converter.Parse(personEntitiy);
        }

        // Method responsible for deleting a person from an ID
        public void Delete(long id)
        {
            _repository.Delete(id);
        }
    }
}