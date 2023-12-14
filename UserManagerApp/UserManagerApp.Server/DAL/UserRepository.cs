using MongoDB.Driver;
using UserManagerApp.Server.Domain;

namespace UserManagerApp.Server.DAL;

public interface IUserRepository
{
    Task<IReadOnlyCollection<User>> GetAll();
    Task Add(User user);
}

public class UserRepository : IUserRepository
{
    private readonly IMongoDatabase _mongoDatabase;

    public UserRepository(IMongoDatabase mongoDatabase)
    {
        _mongoDatabase = mongoDatabase;
    }

    public async Task<IReadOnlyCollection<User>> GetAll()
    {
        var collection = GetCollection();
        return await collection.Find(Builders<User>.Filter.Empty).ToListAsync();
    }

    public async Task Add(User user)
    {
        var collection = GetCollection();
        await collection.InsertOneAsync(user);
    }

    private IMongoCollection<User> GetCollection()
    {
        return _mongoDatabase.GetCollection<User>("users");
    }
}