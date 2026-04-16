using Chefia.Api.Http;
using Chefia.App.Dtos.ProductCategory.Request;
using Chefia.App.Dtos.ProductCategory.Response;
using Chefia.App.Usecases.ProductCategory.Create;
using Microsoft.AspNetCore.Mvc;

namespace Chefia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductCategoryController : ControllerBase
{
    private readonly ICreateProductCategoryUsecase _createProductCategoryUsecase;

    public ProductCategoryController(ICreateProductCategoryUsecase createProductCategoryUsecase)
    {
        _createProductCategoryUsecase = createProductCategoryUsecase;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CreateProductCategoryResponse>>> Create([FromBody] CreateProductCategoryRequest request)
    {
        var response = await _createProductCategoryUsecase.Execute(request);
        return this.ToApiResponse(response);
    }

}
