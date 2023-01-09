using CacheStrategy.Models;

namespace CacheStrategy.Repositories
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();
    }
}
