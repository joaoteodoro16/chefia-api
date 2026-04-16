using Chefia.App.Dtos.Result;
using Chefia.App.Dtos.Company.Response;

namespace Chefia.App.Usecases.Company.Create;

public interface ICreateCompanyUsecase
{
    public Task<Result<CreateCompanyResponse>> Execute(CreateCompanyRequest request);
}

