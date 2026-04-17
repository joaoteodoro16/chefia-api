using Chefia.Domain.Entities;
using Chefia.Domain.Repositories;
using Chefia.Infra.Context;

namespace Chefia.Infra.Repositories;

public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
{
    public OrderItemRepository(AppDbContext context) : base(context)
    {
    }
}
