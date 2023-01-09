using CacheStrategy.Models;
using Microsoft.Extensions.Caching.Memory;

namespace CacheStrategy.Repositories.Caching
{
    public class PersonCachingDecorator<T> : IPersonRepository where T : IPersonRepository
    {
        private readonly IMemoryCache _cache;
        private readonly T _inner;

        public PersonCachingDecorator(IMemoryCache cache, T inner)
        {
            this._cache = cache;
            this._inner = inner;
        }

        public IEnumerable<Person> GetAll()
        {
            var key = "Persons";

            var items = _cache.Get<IEnumerable<Person>>(key);

            if(items == null)
            {
                items = _inner.GetAll();

                if(items != null)
                {
                    _cache.Set(key, items, TimeSpan.FromMinutes(1));
                }
            }

            return items;
        }
    }
}
