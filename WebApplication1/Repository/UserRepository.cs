using MongoDB.Driver;
using WebApplication1.Documents;
using WebApplication1.Mongo;

namespace WebApplication1.Repository;

public class UserRepository : IUserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(IMongoDBSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _users = database.GetCollection<User>("Users");
    }

    public IQueryable<User> GetAll()
    {
        return _users.AsQueryable();
    }

    public async Task<User> GetByIdAsync(string id) =>
        await _users.Find<User>(user => user.Id == id).FirstOrDefaultAsync();

    public async Task<User> GetByUserIdAsync(string userId) =>
        await _users.Find<User>(user => user.UserId == userId).FirstOrDefaultAsync();

    public async Task CreateAsync(UserDTO user) =>
        await _users.InsertOneAsync(new User()
        {
            UserId = user.UserId,
            Name = user.Name
        });

    public async Task UpdateAsync(string id, User user) =>
        await _users.ReplaceOneAsync(user => user.Id == id, user);

    public async Task DeleteAsync(string id) =>
        await _users.DeleteOneAsync(user => user.Id == id);

    public Task UpdateAsync(string id, UserDTO entity)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _users.Find(_ => true).ToListAsync();
    }
}
