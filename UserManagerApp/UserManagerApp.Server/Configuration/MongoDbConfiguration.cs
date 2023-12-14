namespace UserManagerApp.Server.Configuration;

public class MongoDbConfiguration
{
    public string ConnectionString { get; set; } = string.Empty;
    public string Database { get; set; } = string.Empty;
}