using Chefia.App.Dtos.Company.Response;
using Chefia.App.Dtos.Result;

namespace Chefia.App.Usecases.Company.GetAll;

public interface IGetCompaniesUsecase
{
    public Task<Result<List<GetCompanyResponse>>> Execute();
}
