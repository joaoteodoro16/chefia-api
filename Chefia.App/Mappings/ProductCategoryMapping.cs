using Chefia.App.Dtos.ProductCategory.Response;
using Chefia.Domain.Entities;

namespace Chefia.App.Mappings;

public class ProductCategoryMapping
{
    public static ProductCategory CreateResponseToEntity(Dtos.ProductCategory.Request.CreateProductCategoryRequest request, Guid companyId)
    {
        return new ProductCategory(
            request.Name,
            companyId,
            true
        );
    }

    public static CreateProductCategoryResponse EntityToCreateResponse(ProductCategory entity)
    {
        return new CreateProductCategoryResponse(
            entity.Id,
            entity.Name,
            entity.CompanyId,
            true
        );
    }
}
