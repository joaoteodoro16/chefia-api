using Chefia.Domain.Entities;
using Chefia.Domain.Repositories;
using Chefia.Infra.Context;

namespace Chefia.Infra.Repositories;

public class OrderRepository : Repository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

}
