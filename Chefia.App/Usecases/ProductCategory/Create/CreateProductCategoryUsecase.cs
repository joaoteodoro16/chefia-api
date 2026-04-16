using Chefia.App.Common;
using Chefia.App.Dtos.ProductCategory.Request;
using Chefia.App.Dtos.ProductCategory.Response;
using Chefia.App.Dtos.Result;
using Chefia.App.Mappings;
using Chefia.App.Services;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.ProductCategory.Create;

public class CreateProductCategoryUsecase : ICreateProductCategoryUsecase
{
    private readonly IProductCategoryRepository _productCategoryRepository;
    private readonly ICurrentUserService _currentUserService;

    public CreateProductCategoryUsecase(IProductCategoryRepository productCategoryRepository, ICurrentUserService currentUserService)
    {
        _productCategoryRepository = productCategoryRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Result<CreateProductCategoryResponse>> Execute(CreateProductCategoryRequest request)
    {
        var existingCategory = await _productCategoryRepository.GetByNameAsync(request.Name, _currentUserService.CompanyId);

        if (existingCategory != null)
        {
            return Result<CreateProductCategoryResponse>.Failure(Messages.ProductCategoryAlreadyExists, ErrorCode.Conflict);
        }

        var entity = ProductCategoryMapping.CreateResponseToEntity(request, _currentUserService.CompanyId);
        await _productCategoryRepository.AddAsync(entity);

        var response = ProductCategoryMapping.EntityToCreateResponse(entity);
        return Result<CreateProductCategoryResponse>.Success(response, Messages.ProductCategoryCreated);
    }
}
