using Chefia.App.Dtos.Company.Request;
using Chefia.App.Dtos.Company.Response;
using Chefia.App.Dtos.Result;

namespace Chefia.App.Usecases.Company.Update;

public interface IUpdateCompanyUsecase
{
    Task<Result<UpdateCompanyResponse>> Execute(UpdateCompanyRequest request);
}
