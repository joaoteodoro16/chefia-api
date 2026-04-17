using Chefia.Api.Http;
using Chefia.App.Dtos.ProductCategory.Request;
using Chefia.App.Dtos.ProductCategory.Response;
using Chefia.App.Usecases.ProductCategory.Create;
using Chefia.App.Usecases.ProductCategory.Fetch;
using Microsoft.AspNetCore.Mvc;

namespace Chefia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoryController : ControllerBase
{
    private readonly ICreateProductCategoryUsecase _createProductCategoryUsecase;
    private readonly IFetchProductCategoriesUsecase _fetchProductCategoriesUsecase;

    public ProductCategoryController(ICreateProductCategoryUsecase createProductCategoryUsecase, IFetchProductCategoriesUsecase fetchProductCategoriesUsecase)
    {
        _createProductCategoryUsecase = createProductCategoryUsecase;
        _fetchProductCategoriesUsecase = fetchProductCategoriesUsecase;

    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CreateProductCategoryResponse>>> Create([FromBody] CreateProductCategoryRequest request)
    {
        var response = await _createProductCategoryUsecase.Execute(request);
        return this.ToApiResponse(response);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<FetchProductCategoriesResponse>>>> Fetch([FromQuery] bool? active)
    {
        var response = await _fetchProductCategoriesUsecase.ExecuteAsync(active);
        return this.ToApiResponse(response);
    }
}
