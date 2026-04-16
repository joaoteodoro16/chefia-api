namespace Chefia.App.Dtos.Company.Response;

public record CreateCompanyRequest(string Name, string Phone, string Cnpj, Guid InitialUserId);


// public string Name { get; private set; }
//     public string Phone { get; private set; }
//     public string Cnpj { get; private set; }