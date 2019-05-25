using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class CustomerInOrderRepository : BaseRepository<CustomerInOrder>
    {
        public CustomerInOrderRepository(string sqlConnection) : base(sqlConnection)
        {
        }
    }
}
