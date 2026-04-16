namespace Chefia.App.Dtos.Product.Response;

public record CreateProductResponse(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    bool Fractional,
    bool Active,
    Guid CompanyId,
    bool IsAditional,
    Guid? CategoryId
);
