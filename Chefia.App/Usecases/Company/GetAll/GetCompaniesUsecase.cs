using Chefia.App.Dtos.Company.Response;
using Chefia.App.Dtos.Result;
using Chefia.App.Mappings;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.Company.GetAll;

public class GetCompaniesUsecase : IGetCompaniesUsecase
{
    private readonly ICompanyRepository _companyRepository;

    public GetCompaniesUsecase(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Result<List<GetCompanyResponse>>> Execute()
    {
        var companies = await _companyRepository.GetAllAsync();

        var response = companies.Select(c => CompanyMapping.ToGetCompanyResponse(c)).ToList();

        if (response.Count == 0)
        {
            return Result<List<GetCompanyResponse>>.Success(response, "Nenhuma empresa encontrada.");
        }

        return Result<List<GetCompanyResponse>>.Success(response, "Empresas recuperadas com sucesso.");
    }
}
