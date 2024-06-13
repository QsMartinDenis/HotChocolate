namespace WebApplication1.Mongo;

public class MongoDBSettings : IMongoDBSettings
{
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}
