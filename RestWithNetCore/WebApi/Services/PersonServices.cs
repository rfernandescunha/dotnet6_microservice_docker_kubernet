using WebApi.Model;
using WebApi.Services.Interfaces;

namespace WebApi.Services
{
    public class PersonServices : IPersonServices
    {
        public async Task<bool> Delete(long Id)
        {
            return await Task.Run(()=> true);
        }

        public async Task<Person> Find(long Id)
        {
            return await Task.Run(() => new Person());
        }

        public async Task<IEnumerable<Person>> FindAll()
        {
            return await Task.Run(() => new List<Person>());
        }

        public async Task<Person> Insert(Person person)
        {
            return await Task.Run(() => person);
        }

        public async Task<Person> Update(Person person)
        {
            return await Task.Run(() => person);
        }
    }
}
