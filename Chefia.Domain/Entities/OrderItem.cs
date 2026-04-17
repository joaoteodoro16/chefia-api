namespace Chefia.Domain.Entities;

public class OrderItem : BaseEntity
{
    public Guid ProductId { get; private set; }
    public int Quantity { get; private set; }
    public decimal UnitPrice { get; private set; }
    public decimal TotalPrice => Quantity * UnitPrice;
    public Guid CompanyId { get; private set; }
    public Guid OrderId { get; private set; }
    public string? Description { get; private set; }

    protected OrderItem() { }

    public OrderItem(Guid productId, int quantity, decimal unitPrice, Guid companyId, string? description, Guid orderId)
    {
        SetProductId(productId);
        SetQuantity(quantity);
        SetUnitPrice(unitPrice);
        SetDescription(description);
        AssignToOrder(orderId);
        CompanyId = companyId;
    }

    public void SetProductId(Guid productId)
    {
        ProductId = productId;
    }

    public void SetQuantity(int quantity)
    {
        Quantity = quantity;
    }

    public void SetUnitPrice(decimal unitPrice)
    {
        UnitPrice = unitPrice;
    }

    public void SetDescription(string? description)
    {
        Description = description;
    }

    public void AssignToOrder(Guid orderId)
    {
        OrderId = orderId;
    }
}
