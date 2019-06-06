using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class CarInOrderRepository : BaseRepository<CarInOrder>
    {
        public CarInOrderRepository(string sqlConnection) : base(sqlConnection)
        {
        }
    }
}
