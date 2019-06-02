using DataAccess.SqlDbConnection;

namespace WebFormsMsMqClient
{
    public static class Singleton
    {
        private static string connectionString = @"Data Source = Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\SASHA\CarSalonDB.mdf;Integrated Security=True;Connect Timeout=30";
        public static SqlDbConnectionUnitOfWork UnitOfWork = new SqlDbConnectionUnitOfWork(connectionString);
    }
}