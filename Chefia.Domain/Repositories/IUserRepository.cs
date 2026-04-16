using Chefia.Domain.Entities;

namespace Chefia.Domain.Repositories;

public interface IUserRepository : IRepository<User>
{
    public Task<User?> GetByEmailAsync(string email);
}
