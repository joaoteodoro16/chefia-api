namespace Chefia.App.Dtos.ProductCategory.Request;

public record UpdateProductCategoryRequest(
    Guid Id,
    string Name,
    bool Active
);
