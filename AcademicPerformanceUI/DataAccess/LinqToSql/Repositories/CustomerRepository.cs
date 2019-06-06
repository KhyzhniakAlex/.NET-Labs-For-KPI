using DataAccess.Models;
using DataAccess.LinqToSql.Repository;

namespace DataAccess.LinqToSql.Repositories
{
    public class CustomerRepository : BaseRepository<Customer>
    {
        public CustomerRepository(string sqlConnection):base(sqlConnection)
        {
        }
    }
}
