namespace Chefia.App.Dtos.Product.Request;

public record UpdateProductRequest(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    bool Fractional,
    bool Active,
    bool IsAditional,
    Guid? CategoryId
);
