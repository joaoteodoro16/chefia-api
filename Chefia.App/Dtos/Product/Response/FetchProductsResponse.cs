namespace Chefia.App.Dtos.Product.Response;

public record FetchProductsResponse(
    Guid Id,
    string Name,
    decimal Price,
    string? Description,
    bool Fractional,
    bool Active,
    FetchProductCategoryResponse? Category,
    bool Aditional
);

public record FetchProductCategoryResponse(
    Guid Id,
    string Name
);

