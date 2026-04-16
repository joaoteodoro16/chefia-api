using Chefia.Api.Http;
using Chefia.App.Dtos.Product.Request;
using Chefia.App.Dtos.Product.Response;
using Chefia.App.Usecases.Product.Create;
using Microsoft.AspNetCore.Mvc;

namespace Chefia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ICreateProductUsecase _createProductUsecase;

    public ProductController(ICreateProductUsecase createProductUsecase)
    {
        _createProductUsecase = createProductUsecase;
    }


    [HttpPost]
    public async Task<ActionResult<ApiResponse<CreateProductResponse>>> CreateProduct([FromBody] CreateProductRequest request)
    {
        var response = await _createProductUsecase.ExecuteAsync(request);
        return this.ToApiResponse(response);
    }
}
