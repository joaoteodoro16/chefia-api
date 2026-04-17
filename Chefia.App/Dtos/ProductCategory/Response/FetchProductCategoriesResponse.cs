namespace Chefia.App.Dtos.ProductCategory.Response;

public record FetchProductCategoriesResponse(
    Guid Id,
    string Name,
    bool Active
);
