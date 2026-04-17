using Chefia.Domain.Entities;
using Chefia.Domain.Repositories;
using Chefia.Infra.Repositories;

namespace Chefia.Infra.Context.ContextMapping;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }
}
