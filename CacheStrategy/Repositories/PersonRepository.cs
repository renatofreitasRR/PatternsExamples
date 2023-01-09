using CacheStrategy.Models;

namespace CacheStrategy.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public PersonRepository() { }

        public IEnumerable<Person> GetAll()
        {
            var personList = new List<Person>();

            personList.Add(new Person("Renato"));
            personList.Add(new Person("Vanessa"));
            personList.Add(new Person("Ruthe"));
            personList.Add(new Person("Ronaldo"));
            personList.Add(new Person("Maria"));

            return personList;
        }
    }
}
