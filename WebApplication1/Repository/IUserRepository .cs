using WebApplication1.Documents;

namespace WebApplication1.Repository;

public interface IUserRepository 
{
    Task<User> GetByUserIdAsync(string userId);
    IQueryable<User> GetAll();
    Task<IEnumerable<User>> GetAllUsers();
    Task<User> GetByIdAsync(string id);
    Task CreateAsync(UserDTO entity);
    Task UpdateAsync(string id, UserDTO entity);
    Task DeleteAsync(string id);
}
