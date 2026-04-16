using Chefia.App.Dtos.Product.Request;
using Chefia.App.Dtos.Product.Response;
using Chefia.Domain.Entities;

namespace Chefia.App.Mappings;

public class ProductMapping
{
    public static CreateProductResponse ToCreateProductResponse(Domain.Entities.Product product)
    {
        return new CreateProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Fractional,
            product.Active,
            product.CompanyId,
            product.IsAditional,
            product.ProductCategoryId
        );
    }

    public static Product ToProduct(CreateProductRequest request, Guid companyId)
    {
        return new Product(
            request.Name,
            request.Price,
            request.Description,
            request.Fractional,
            companyId,
            request.IsAditional,
            request.CategoryId
        );
    }

    public static UpdateProductResponse ToUpdateProductResponse(Domain.Entities.Product product)
    {
        return new UpdateProductResponse(
            product.Id,
            product.Name,
            product.Description,
            product.Price,
            product.Fractional,
            product.CompanyId,
            product.IsAditional,
            product.ProductCategoryId
        );
    }

    public static FetchProductsResponse ToFetchProductsResponse(Product product)
    {
        var categoryResponse = _ToFetchProductCategoryResponse(product.ProductCategory);

        return new FetchProductsResponse(
            product.Id,
            product.Name,
            product.Price,
            product.Description,
            product.Fractional,
            product.Active,
            categoryResponse,
            product.IsAditional
        );
    }

    private static FetchProductCategoryResponse? _ToFetchProductCategoryResponse(ProductCategory? category)
    {
        if (category == null) return null;

        return new FetchProductCategoryResponse(
            category.Id,
            category.Name
        );
    }


}
