using APIRest_ASP.Data.Converter.Contract;
using APIRest_ASP.Data.VO;
using APIRest_ASP.Model;

namespace APIRest_ASP.Data.Converter.Implementation
{
    public class PersonConverter : IParser<PersonVO, Person>, IParser<Person, PersonVO>
    {

        //VO para person
        public Person Parse(PersonVO origin)
        {
            if (origin == null) return null;
                return new Person
                {
                    Id = origin.Id,
                    FirstName = origin.FirstName,
                    LastName = origin.LastName,
                    Address = origin.Address,
                    Gender = origin.Gender,
                };

        }

        public List<Person> Parse(List<PersonVO> origin)
        {

            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        //Person para VO
        public PersonVO Parse(Person origin)
        {
            if (origin == null) return null;
            return new PersonVO
            {
                Id = origin.Id,
                FirstName = origin.FirstName,
                LastName = origin.LastName,
                Address = origin.Address,
                Gender = origin.Gender,
            };
        }

        public List<PersonVO> Parse(List<Person> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
