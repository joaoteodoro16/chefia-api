using Chefia.Domain.Entities;
using Chefia.Domain.Repositories;
using Chefia.Infra.Context;

namespace Chefia.Infra.Repositories;

public class TableRepository : Repository<Table>, ITableRepository
{
    public TableRepository(AppDbContext context) : base(context)
    {
    }
}
