using DataAccess.Models;
using DataAccess.SqlDbConnection.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess.SqlDbConnection.Repositories
{
    public class CustomerInOrderRepository : BaseRepository<CustomerInOrder>
    {
        public CustomerInOrderRepository(string sqlConnection) : base(sqlConnection)
        {
        }

        public override Task<List<CustomerInOrder>> GetAllEntitiesAsync()
        {
            var text = SqlHelper.GetAllSqlText<CustomerInOrder>();
            var reader = ExecuteReader(text);
            var list = new List<CustomerInOrder>();
            while (reader.Read())
            {
                list.Add(new CustomerInOrder()
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
