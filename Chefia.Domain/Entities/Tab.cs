namespace Chefia.Domain.Entities;

//Semelhante a Comanda
public class Tab : BaseEntity
{
    public int Number { get; private set; }
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public Guid CompanyId { get; private set; }
    public Guid TableId { get; private set; }
    public bool IsOpen { get; private set; }
    private readonly List<Order> _orders = new();
    public IReadOnlyCollection<Order> Orders => _orders;
    public Company Company { get; private set; } = null!;
    public Table Table { get; private set; } = null!;


    protected Tab() { }
    public Tab(int number, string? description, Guid companyId, Guid tableId)
    {
        SetNumber(number);
        SetDescription(description);
        SetIsActive(true);
        CompanyId = companyId;
        TableId = tableId;
        Open();
    }

    public void SetNumber(int number)
    {
        Number = number;
    }

    public void SetDescription(string? description)
    {
        Description = description;
    }

    public void SetIsActive(bool isActive)
    {
        IsActive = isActive;
    }

    public void Open()
    {
        IsOpen = true;
    }

    public void Close()
    {
        IsOpen = false;
    }

    public void AddOrder(Order order)
    {
        if (!IsOpen)
            throw new InvalidOperationException("A comanda está fechada. Não é possível adicionar pedidos.");
        _orders.Add(order);
    }
}
