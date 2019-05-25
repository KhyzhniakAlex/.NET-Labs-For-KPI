using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Customer>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Customer>();
            var reader = ExecuteReader(text);
            var list = new List<Customer>();
            while (reader.Read())
            {
                list.Add(new Customer()
                {
                    Id = (Guid)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    PassportSeries = reader["PassportSeries"].ToString(),
                    AccoutId = reader["AccoutId"].ToString()
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
