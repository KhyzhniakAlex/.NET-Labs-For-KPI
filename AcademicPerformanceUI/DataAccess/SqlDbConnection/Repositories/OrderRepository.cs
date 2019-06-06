using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(string sqlConnection):base(sqlConnection)
        {
        }

        public override Task<List<Order>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<Order>();
            var reader = ExecuteReader(text);
            var list = new List<Order>();
            while (reader.Read())
            {
                list.Add(new Order()
                {
                    Id = (Guid)reader["Id"],
                    StartDate = (DateTime)reader["StartDate"],
                    EndDate = (DateTime)reader["EndDate"],
                    Sum = (double)reader["Sum"],
                    CustomerId = (Guid)reader["CustomerId"],
                    ManagerId = (Guid)reader["ManagerId"]
                });
            }
            reader.Close();
            return Task.FromResult(list);
        }
    }
}
