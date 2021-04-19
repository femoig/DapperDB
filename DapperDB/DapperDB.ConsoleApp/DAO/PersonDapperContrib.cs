using Dapper.Contrib.Extensions;
using DapperDB.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDB.ConsoleApp.DAO
{
    public class PersonDapperContrib : DatabaseConnection, IPersonRepository
    {
        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> people;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                people = connection.GetAll<Person>();
            }

            return people;
        }

        public void Add(Person person)
        {
            using (var connection = new SqlConnection(GetConnectionString()))
            {                
                connection.Insert<Person>(person);
            }
        }

        public void Delete(Person person)
        {
            var result = false;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                result = connection.Delete<Person>(person);
            }
        }

        public Person Get(int id)
        {
            Person person;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                person = connection.Get<Person>(id);
            }

            return person;
        }
    }
}
