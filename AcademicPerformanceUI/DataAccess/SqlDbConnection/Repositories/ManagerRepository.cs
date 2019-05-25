using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class ManagerRepository : BaseRepository<Manager>
    {
        public ManagerRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Manager>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Manager>();
            var reader = ExecuteReader(text);
            var list = new List<Manager>();
            while (reader.Read())
            {
                list.Add(new Manager()
                {
                    Id = (Guid)reader["Id"],
                    FirstName = reader["FirstName"].ToString(),
                    LastName = reader["LastName"].ToString(),
                    PhoneNumber = reader["PhoneNumber"].ToString(),
                    Salary = (double)reader["Salary"],
                    Position = reader["Position"].ToString(),
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
