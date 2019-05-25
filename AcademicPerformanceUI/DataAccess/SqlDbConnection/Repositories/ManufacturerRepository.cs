using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>
    {
        public ManufacturerRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Manufacturer>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Manufacturer>();
            var reader = ExecuteReader(text);
            var list = new List<Manufacturer>();
            while (reader.Read())
            {
                list.Add(new Manufacturer()
                {
                    Id = (Guid)reader["Id"],
                    OfficePhoneNumber = reader["OfficePhoneNumber"].ToString(),
                    Name = reader["Name"].ToString(),
                    Country = reader["Country"].ToString()
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
