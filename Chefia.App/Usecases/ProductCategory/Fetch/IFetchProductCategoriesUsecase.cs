using Chefia.App.Dtos.ProductCategory.Response;
using Chefia.App.Dtos.Result;

namespace Chefia.App.Usecases.ProductCategory.Fetch;

public interface IFetchProductCategoriesUsecase
{
    public Task<Result<List<FetchProductCategoriesResponse>>> ExecuteAsync(bool? active);
}
