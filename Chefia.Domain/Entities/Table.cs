namespace Chefia.Domain.Entities;

public class Table : BaseEntity
{
    public int Number { get; private set; }
    public string? Description { get; private set; }
    public bool IsActive { get; private set; }
    public Guid CompanyId { get; private set; }

    protected Table() { }

    public Table(int number, string? description, Guid companyId)
    {
        setNumber(number);
        setDescription(description);
        setIsActive(true);
        CompanyId = companyId;
    }

    public void setNumber(int number)
    {
        Number = number;
    }

    public void setDescription(string? description)
    {
        Description = description;
    }

    public void setIsActive(bool isActive)
    {
        IsActive = isActive;
    }
}
