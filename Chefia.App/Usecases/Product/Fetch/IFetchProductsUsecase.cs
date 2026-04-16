using Chefia.App.Dtos.Product.Request;
using Chefia.App.Dtos.Product.Response;
using Chefia.App.Dtos.Result;

namespace Chefia.App.Usecases.Product.Fetch;

public interface IFetchProductsUsecase
{
    Task<Result<List<FetchProductsResponse>>> ExecuteAsync(FetchProductsRequest request);
}
