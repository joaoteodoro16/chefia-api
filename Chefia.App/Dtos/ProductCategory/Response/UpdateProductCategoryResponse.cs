namespace Chefia.App.Dtos.ProductCategory.Response;

public record UpdateProductCategoryResponse(
    Guid Id,
    string Name,
    bool Active,
    Guid CompanyId
);
