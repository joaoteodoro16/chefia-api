using Chefia.Api.Http;
using Chefia.App.Dtos.Product.Request;
using Chefia.App.Dtos.Product.Response;
using Chefia.App.Usecases.Product.Create;
using Chefia.App.Usecases.Product.Fetch;
using Chefia.App.Usecases.Product.Update;
using Microsoft.AspNetCore.Mvc;

namespace Chefia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly ICreateProductUsecase _createProductUsecase;
    private readonly IUpdateProductUsecase _updateProductUsecase;
    private readonly IFetchProductsUsecase _fetchProductsUsecase;

    public ProductController(ICreateProductUsecase createProductUsecase, IUpdateProductUsecase updateProductUsecase, IFetchProductsUsecase fetchProductsUsecase)
    {
        _createProductUsecase = createProductUsecase;
        _updateProductUsecase = updateProductUsecase;
        _fetchProductsUsecase = fetchProductsUsecase;

    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CreateProductResponse>>> CreateProduct([FromBody] CreateProductRequest request)
    {
        var response = await _createProductUsecase.ExecuteAsync(request);
        return this.ToApiResponse(response);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<UpdateProductResponse>>> UpdateProduct([FromBody] UpdateProductRequest request)
    {
        var response = await _updateProductUsecase.ExecuteAsync(request);
        return this.ToApiResponse(response);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<FetchProductsResponse>>>> GetProducts([FromQuery] FetchProductsRequest request)
    {
        var response = await _fetchProductsUsecase.ExecuteAsync(request);
        return this.ToApiResponse(response);
    }
}
