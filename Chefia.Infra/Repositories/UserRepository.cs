using Chefia.Domain.Entities;
using Chefia.Domain.Repositories;
using Chefia.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Chefia.Infra.Repositories;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(o => o.Email == email);
    }

}
