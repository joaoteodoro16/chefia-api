using Chefia.App.Dtos.ProductCategory.Request;
using Chefia.App.Dtos.ProductCategory.Response;
using Chefia.App.Dtos.Result;

namespace Chefia.App.Usecases.ProductCategory.Update;

public interface IUpdateProductCategoryUsecase
{
    public Task<Result<UpdateProductCategoryResponse>> ExecuteAsync(UpdateProductCategoryRequest request);
}
