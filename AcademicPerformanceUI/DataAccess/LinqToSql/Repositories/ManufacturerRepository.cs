using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class ManufacturerRepository : BaseRepository<Manufacturer>
    {
        public ManufacturerRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
