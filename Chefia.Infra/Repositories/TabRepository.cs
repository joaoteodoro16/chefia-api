using Chefia.Domain.Entities;
using Chefia.Domain.Repositories;
using Chefia.Infra.Context;

namespace Chefia.Infra.Repositories;

public class TabRepository : Repository<Tab>, ITabRepository
{
    public TabRepository(AppDbContext context) : base(context)
    {
    }
}
