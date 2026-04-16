namespace Chefia.Domain.Entities;

public class Product : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public decimal Price { get; private set; }
    public string? Description { get; private set; } = string.Empty;
    public bool Fractional { get; private set; }
    public bool Active { get; private set; }
    public Guid CompanyId { get; private set; }
    public Company Company { get; private set; } = null!;
    public bool IsAditional { get; private set; }
    public Guid? ProductCategoryId { get; private set; }
    public ProductCategory? ProductCategory { get; private set; }

    protected Product() { }

    public Product(string name, decimal price, string? description, bool fractional, Guid companyId, bool isAditional, Guid? productCategoryId = null)
    {
        Name = name;
        Price = price;
        Description = description;
        Fractional = fractional;
        Active = true;
        CompanyId = companyId;
        IsAditional = isAditional;
        ProductCategoryId = productCategoryId;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Nome não pode ser vazio.");
        Name = name;
    }

    public void SetPrice(decimal price)
    {
        if (price < 0)
            throw new ArgumentException("Preço não pode ser negativo.");
        Price = price;
    }

    public void SetDescription(string? description)
    {
        Description = description;
    }

    public void SetFractional(bool fractional)
    {
        Fractional = fractional;
    }

    public void SetActive(bool active)
    {
        Active = active;
    }

    public void SetCompanyId(Guid companyId)
    {
        CompanyId = companyId;
    }

    public void SetIsAditional(bool isAditional)
    {
        IsAditional = isAditional;
    }

    public void SetProductCategoryId(Guid? productCategoryId)
    {
        ProductCategoryId = productCategoryId;
    }
}
