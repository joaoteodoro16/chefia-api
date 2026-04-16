using Chefia.App.Common;
using Chefia.App.Dtos.Product.Request;
using Chefia.App.Dtos.Product.Response;
using Chefia.App.Dtos.Result;
using Chefia.App.Mappings;
using Chefia.App.Services;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.Product.Create;

public class CreateProductUsecase : ICreateProductUsecase
{
    private readonly IProductRepository _productRepository;
    private readonly ICurrentUserService _currentUserService;

    public CreateProductUsecase(IProductRepository productRepository, ICurrentUserService currentUserService)
    {
        _productRepository = productRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Result<CreateProductResponse>> ExecuteAsync(CreateProductRequest request)
    {
        var productExists = await _productRepository.GetByNameAsync(request.Name);

        if (productExists != null)
            return Result<CreateProductResponse>.Failure(Messages.ProductNameConflict, ErrorCode.Conflict);

        var product = ProductMapping.ToProduct(request, _currentUserService.CompanyId);
        await _productRepository.AddAsync(product);

        var response = ProductMapping.ToCreateProductResponse(product);
        return Result<CreateProductResponse>.Success(response);
    }
}
