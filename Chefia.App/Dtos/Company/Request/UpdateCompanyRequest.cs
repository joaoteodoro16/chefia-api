namespace Chefia.App.Dtos.Company.Request;

public record UpdateCompanyRequest(Guid Id, string Name, string Phone, string Cnpj);
