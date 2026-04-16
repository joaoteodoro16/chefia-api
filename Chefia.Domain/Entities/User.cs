using Chefia.Domain.Enums;
using Chefia.Domain.ValueObjects;

namespace Chefia.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;
    public OperatorRole Role { get; private set; }
    public Guid? CompanyId { get; private set; }
    public Company? Company { get; private set; }
    public bool Active { get; private set; }

    public User() { }

    public User(string name, string email, string password, int role, Guid? companyId)
    {
        UpdateName(name);
        _UpdateEmail(email);
        UpdatePassword(null, password);
        Role = role.ToOperatorRole();
        UpdateCompanyId(companyId);
        Active = true;
    }

    public void UpdatePassword(string? oldPassword, string password)
    {
        if (string.IsNullOrEmpty(password))
            throw new ArgumentException("Senha não pode ser vazia.");

        if (oldPassword != null && Password != oldPassword)
            throw new ArgumentException("Senha antiga incorreta.");

        Password = password;
    }

    public void UpdateName(string name)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException("Nome não pode ser vazio.");
        Name = name;
    }

    private void _UpdateEmail(string email)
    {
        Email = new Email(email).ToUnformattedString();
    }



    public void UpdateRole(int role, User requester)
    {
        if (requester.Role != OperatorRole.Admin)
            throw new UnauthorizedAccessException("Apenas administradores podem alterar a role.");

        Role = role.ToOperatorRole();
    }

    public void UpdateCompanyId(Guid? companyId)
    {
        //CompanyId so vai ser null quando o usuario for criar o primeiro usuario admin
        if (CompanyId == null && Role == OperatorRole.Admin)
        {
            CompanyId = companyId;
        }
    }

    public void UpdateStatus(bool active)
    {
        Active = active;
    }
}
