namespace Services.Settings
{
    public static class SettingList
    {
        public static SerializationType GetSerializationType { get; set; } = SerializationType.Xml;
        public static DataProvider GetDataProvider { get; set; } = DataProvider.LinqToSql;
        public static string GetConnectionString { get; set; } = @"Data Source = Data Source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\SASHA\CarSalonDB.mdf;Integrated Security=True;Connect Timeout=30";
    }

    public enum SerializationType
    {
        Xml,
        Json,
        DataContract
    }

    public enum DataProvider
    {
        InMemory,
        SqlDbConnection,
        LinqToSql
    }
}
