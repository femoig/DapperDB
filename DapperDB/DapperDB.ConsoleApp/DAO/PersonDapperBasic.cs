using Dapper;
using DapperDB.ConsoleApp.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDB.ConsoleApp.DAO
{
    public class PersonDapperBasic : DatabaseConnection, IPersonRepository
    {

        public IEnumerable<Person> Get()
        {
            IEnumerable<Person> people;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                people = connection.Query<Person>(@"SELECT * FROM Person");
            }

            return people;
        }

        public void Add(Person person)
        {
            var insertQuery = @"INSERT [Person] VALUES(@FirstName, @LastName, @BirthDate)";
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                var totalRows = connection.Execute(insertQuery, new[] {
                    new { FirstName = person.FirstName, LastName=person.LastName, BirthDate=person.BirthDate}                    
                });
            }
        }

        public void Delete(Person person)
        {
            var sqlQuery = $"DELETE PERSON WHERE ID='{person.Id}'";
            var result = 0;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                result = connection.Execute(sqlQuery);
            }
        }

        public Person Get(int id)
        {
            Person people;
            using (var connection = new SqlConnection(GetConnectionString()))
            {
                people = connection.Query<Person>(@"SELECT * FROM Person WHERE Id = @Id", new { Id = id }).FirstOrDefault();
            }

            return people;
        }
    }
}
