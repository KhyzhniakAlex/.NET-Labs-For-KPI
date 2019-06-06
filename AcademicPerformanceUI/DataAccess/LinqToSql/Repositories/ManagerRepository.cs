using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class ManagerRepository : BaseRepository<Manager>
    {
        public ManagerRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
