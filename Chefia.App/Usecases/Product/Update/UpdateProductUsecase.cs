using Chefia.App.Common;
using Chefia.App.Dtos.Product.Request;
using Chefia.App.Dtos.Product.Response;
using Chefia.App.Dtos.Result;
using Chefia.App.Mappings;
using Chefia.App.Services;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.Product.Update;

public class UpdateProductUsecase : IUpdateProductUsecase
{
    private readonly IProductRepository _repository;
    private readonly ICurrentUserService _currentUserService;

    public UpdateProductUsecase(IProductRepository repository, ICurrentUserService currentUserService)
    {
        _repository = repository;
        _currentUserService = currentUserService;
    }

    public async Task<Result<UpdateProductResponse>> Execute(UpdateProductRequest request)
    {
        var product = await _repository.GetByIdAsync(request.Id);

        if (product == null)
            return Result<UpdateProductResponse>.Failure(Messages.ProductNotFound, ErrorCode.NotFound);

        product.SetName(request.Name);
        product.SetDescription(request.Description);
        product.SetPrice(request.Price);
        product.SetFractional(request.Fractional);
        product.SetIsAditional(request.IsAditional);
        product.SetCompanyId(_currentUserService.CompanyId);
        product.SetProductCategoryId(request.CategoryId);
        product.SetActive(request.Active);

        await _repository.UpdateAsync(product);

        return Result<UpdateProductResponse>.Success(ProductMapping.ToUpdateProductResponse(product));
    }

}
