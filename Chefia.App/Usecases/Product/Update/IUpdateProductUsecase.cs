using Chefia.App.Dtos.Product.Request;
using Chefia.App.Dtos.Product.Response;
using Chefia.App.Dtos.Result;

namespace Chefia.App.Usecases.Product.Update;

public interface IUpdateProductUsecase
{
    public Task<Result<UpdateProductResponse>> Execute(UpdateProductRequest request);
}
