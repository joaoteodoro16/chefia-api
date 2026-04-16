using Chefia.App.Dtos.Product.Request;
using Chefia.App.Dtos.Product.Response;
using Chefia.App.Dtos.Result;

namespace Chefia.App.Usecases.Product.Create;

public interface ICreateProductUsecase
{
    public Task<Result<CreateProductResponse>> ExecuteAsync(CreateProductRequest request);
}
