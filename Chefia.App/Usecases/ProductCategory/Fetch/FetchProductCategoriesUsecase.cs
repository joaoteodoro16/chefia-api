using Chefia.App.Dtos.ProductCategory.Response;
using Chefia.App.Dtos.Result;
using Chefia.App.Services;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.ProductCategory.Fetch;

public class FetchProductCategoriesUsecase : IFetchProductCategoriesUsecase
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly ICurrentUserService _currentUserService;
    public FetchProductCategoriesUsecase(IProductCategoryRepository productCategoryRepository, ICurrentUserService currentUserService)
    {
        _productCategoryRepository = productCategoryRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Result<List<FetchProductCategoriesResponse>>> ExecuteAsync(bool? active)
    {
        var companyId = _currentUserService.CompanyId;
        var categories = await _productCategoryRepository.FetchProductCategoriesAsync(active, companyId);
        var response = categories.Select(x => new FetchProductCategoriesResponse(x.Id, x.Name, x.Active)).ToList();
        return Result<List<FetchProductCategoriesResponse>>.Success(response);
    }

}
