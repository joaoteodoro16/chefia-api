namespace Chefia.Domain.Entities;

public class Order : BaseEntity
{
    //Numero sequencial para cada comanda ou mesa, para facilitar a identificação do pedido
    public int OrderNumber { get; private set; }
    public string? Description { get; private set; }
    public decimal Price { get; private set; }
    public Guid CompanyId { get; private set; }
    public Company Company { get; private set; } = null!;
    public Guid? TableId { get; private set; }
    public Guid? TabId { get; private set; }
    public Table? Table { get; private set; }
    public Tab? Tab { get; private set; }
    private readonly List<OrderItem> _orderItems = new();
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
    protected Order() { }

    public Order(int orderNumber, string? description, Guid companyId, Guid? tableId = null, Guid? tabId = null)
    {
        SetOrderNumber(orderNumber);
        SetDescription(description);
        SetTableOrTab(tableId, tabId);
        CompanyId = companyId;
    }

    public void SetOrderNumber(int orderNumber)
    {
        OrderNumber = orderNumber;
    }

    public void SetDescription(string? description)
    {
        Description = description;
    }


    public void AddOrderItem(OrderItem orderItem)
    {
        _orderItems.Add(orderItem);
    }

    public void SetTableOrTab(Guid? tableId, Guid? tabId)
    {
        if (tableId.HasValue || tabId.HasValue)
        {
            TableId = tableId;
            TabId = tabId;
        }
        else
        {
            throw new InvalidOperationException("É necessário informar uma mesa ou uma comanda para associar o pedido.");
        }
    }

    public void SetPrice()
    {
        decimal total = Price;
        foreach (var item in OrderItems)
        {
            total += item.TotalPrice;
        }
        Price = total;
    }
}
