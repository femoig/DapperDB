using System.Collections.Generic;
using DapperDB.ConsoleApp.Model;

namespace DapperDB.ConsoleApp.DAO
{
    public interface IPersonRepository
    {
        void Add(Person person);
        void Delete(Person person);
        IEnumerable<Person> Get();
        Person Get(int id);
    }
}