using WebApi.Model;

namespace WebApi.Services.Interfaces
{
    public interface IPersonServices
    {
        Task<Person> Insert(Person person);
        Task<Person> Update(Person person);
        Task<Person> Find(long Id);
        Task<IEnumerable<Person>> FindAll();
        Task<bool> Delete(long Id);

    }
}
