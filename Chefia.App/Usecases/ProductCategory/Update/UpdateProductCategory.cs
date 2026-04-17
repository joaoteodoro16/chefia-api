using Chefia.App.Common;
using Chefia.App.Dtos.ProductCategory.Request;
using Chefia.App.Dtos.ProductCategory.Response;
using Chefia.App.Dtos.Result;
using Chefia.App.Services;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.ProductCategory.Update;

public class UpdateProductCategory : IUpdateProductCategoryUsecase
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly ICurrentUserService _currentUserService;

    public UpdateProductCategory(IProductCategoryRepository productCategoryRepository, ICurrentUserService currentUserService)
    {
        _productCategoryRepository = productCategoryRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Result<UpdateProductCategoryResponse>> ExecuteAsync(UpdateProductCategoryRequest request)
    {
        var category = await _productCategoryRepository.GetByIdAsync(request.Id);

        if (category == null)
        {
            return Result<UpdateProductCategoryResponse>.Failure(Messages.ProductCategoryNotFound, ErrorCode.NotFound);
        }

        category.SetName(request.Name);
        category.SetActive(request.Active);
        await _productCategoryRepository.UpdateAsync(category);
        var response = new UpdateProductCategoryResponse(category.Id, category.Name, category.Active, category.CompanyId);
        return Result<UpdateProductCategoryResponse>.Success(response);
    }

}
