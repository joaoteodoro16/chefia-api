namespace Chefia.Domain.Entities;

public class ProductCategory : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public Guid CompanyId { get; private set; }
    public Company Company { get; private set; } = null!;
    public bool Active { get; private set; }
    public List<Product> Products { get; private set; } = new List<Product>();

    public ProductCategory()
    {

    }

    public ProductCategory(string name, Guid companyId, bool active)
    {
        Name = name;
        CompanyId = companyId;
        Active = active;
    }

    public void SetName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Nome não pode ser vazio.");
        Name = name;
    }

    public void SetActive(bool active)
    {
        Active = active;
    }

    public void SetCompanyId(Guid companyId)
    {
        CompanyId = companyId;
    }
}
