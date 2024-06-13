namespace WebApplication1.Mongo;

public interface IMongoDBSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}
