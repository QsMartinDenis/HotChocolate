using Microsoft.AspNetCore.Mvc;
using WebApplication1.CustomFilter;
using WebApplication1.Documents;
using WebApplication1.Repository;

namespace WebApplication1.Queries;

public class Query
{
    [UseFiltering(typeof(CustomStringOperationFilterInputType))]
    public Task<IEnumerable<User>> GetUsers([FromServices] IUserRepository rep)
    {
        return rep.GetAllUsers();
    }

    public async Task<string> CreateUserddd([FromServices] IUserRepository rep, string id, string name)
    {
        await rep.CreateAsync(new UserDTO()
        {
            UserId = id,
            Name = name
        });

        return "ok";
    }
}
