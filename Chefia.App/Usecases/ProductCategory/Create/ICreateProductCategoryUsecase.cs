using Chefia.App.Dtos.ProductCategory.Request;
using Chefia.App.Dtos.ProductCategory.Response;
using Chefia.App.Dtos.Result;

namespace Chefia.App.Usecases.ProductCategory.Create;

public interface ICreateProductCategoryUsecase
{
    public Task<Result<CreateProductCategoryResponse>> Execute(CreateProductCategoryRequest request);
}
