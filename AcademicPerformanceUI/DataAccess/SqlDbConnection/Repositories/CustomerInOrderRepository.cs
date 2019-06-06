using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class CarInOrderRepository : BaseRepository<CarInOrder>
    {
        public CarInOrderRepository(string sqlConnection) : base(sqlConnection)
        {
        }

        public override Task<List<CarInOrder>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<CarInOrder>();
            var reader = ExecuteReader(text);
            var list = new List<CarInOrder>();
            while (reader.Read())
            {
                list.Add(new CarInOrder()
                {
                    Id = (Guid)reader["Id"],
                    OrderId = (Guid)reader["OrderId"],
                    CarId = (Guid)reader["CarId"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
