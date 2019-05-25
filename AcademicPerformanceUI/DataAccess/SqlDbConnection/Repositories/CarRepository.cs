using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class CarRepository : BaseRepository<Car>
    {
        public CarRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Car>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Car>();
            var reader = ExecuteReader(text);
            var list = new List<Car>();
            while (reader.Read())
            {
                list.Add(new Car()
                {
                    Id = (Guid)reader["Id"],
                    Brand = reader["Brand"].ToString(),
                    Model = reader["Model"].ToString(),
                    SerialNumber = reader["SerialNumber"].ToString(),
                    Color = reader["Color"].ToString(),
                    Price = (double)reader["Price"],
                    ManufacturerId = (Guid)reader["ManufacturerId"],
                    ManagerId = (Guid)reader["ManagerId"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
