using Chefia.Domain.Entities;
using Chefia.Domain.ValueObjects;

namespace Chefia.Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string Cnpj { get; private set; } = string.Empty;
    public List<User> Users { get; private set; } = new List<User>();
    public List<Product> Products { get; private set; } = new List<Product>();
    public List<ProductCategory> ProductCategories { get; private set; } = new List<ProductCategory>();


    public Company() { }

    public Company(string name, string phone, string cnpj)
    {
        UpdateName(name);
        UpdatePhone(phone);
        UpdateCnpj(cnpj);
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Nome não pode ser vazio.");
        Name = name;
    }

    public void UpdatePhone(string phone)
    {
        Phone = new Phone(phone).Value;
    }

    public void UpdateCnpj(string cnpj)
    {
        Cnpj = new Cnpj(cnpj).Value;
    }
}
