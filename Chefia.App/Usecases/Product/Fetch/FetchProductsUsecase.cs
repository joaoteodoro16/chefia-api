using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Chefia.App.Dtos.Product.Request;
using Chefia.App.Dtos.Product.Response;
using Chefia.App.Dtos.Result;
using Chefia.App.Mappings;
using Chefia.App.Services;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.Product.Fetch;

public class FetchProductsUsecase : IFetchProductsUsecase
{
    private readonly IProductRepository _productRepository;
    private readonly ICurrentUserService _currentUserService;
    public FetchProductsUsecase(IProductRepository productRepository, ICurrentUserService currentUserService)
    {
        _productRepository = productRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Result<List<FetchProductsResponse>>> ExecuteAsync(FetchProductsRequest request)
    {
        var products = await _productRepository.FetchProductsByCompanyIdAsync(
            request.IsActive,
            request.Name,
            request.CategoryId,
            request.isAditional,
            request.isFractional,
            _currentUserService.CompanyId
        );

        var response = products.Select(ProductMapping.ToFetchProductsResponse).ToList();

        return Result<List<FetchProductsResponse>>.Success(response);
    }
}
