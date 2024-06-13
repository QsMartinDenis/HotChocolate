using WebApplication1.Documents;

namespace WebApplication1.Repository;

public interface IRepository<T>
{
    //Task<IExecutable<T>> GetAllAsync();
    Task<T> GetByIdAsync(string id);
    Task CreateAsync(UserDTO entity);
    Task UpdateAsync(string id, T entity);
    Task DeleteAsync(string id);
}
