using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class CarRepository : BaseRepository<Car>
    {
        public CarRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
