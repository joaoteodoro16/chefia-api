namespace Chefia.App.Dtos.ProductCategory.Response;

public record CreateProductCategoryResponse(
    Guid Id,
    string Name,
    Guid CompanyId,
    bool Active
);
