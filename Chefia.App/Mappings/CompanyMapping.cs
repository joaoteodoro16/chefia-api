using Chefia.App.Dtos.Company.Request;
using Chefia.App.Dtos.Company.Response;

namespace Chefia.App.Mappings;

public class CompanyMapping
{
    public static CreateCompanyResponse ToCreateCompanyResponse(Domain.Entities.Company company)
    {
        return new CreateCompanyResponse(company.Id, company.Name, company.Phone, company.Cnpj);
    }

    public static Domain.Entities.Company ToCompany(CreateCompanyRequest request)
    {
        return new Domain.Entities.Company(request.Name, request.Phone, request.Cnpj);
    }

    public static GetCompanyResponse ToGetCompanyResponse(Domain.Entities.Company company)
    {
        return new GetCompanyResponse(company.Id, company.Name, company.Phone, company.Cnpj);
    }

    public static UpdateCompanyResponse ToUpdateCompanyResponse(Domain.Entities.Company company)
    {
        return new UpdateCompanyResponse(company.Id, company.Name, company.Phone, company.Cnpj);
    }
}
