using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class OrderRepository : BaseRepository<Order>
    {
        public OrderRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
