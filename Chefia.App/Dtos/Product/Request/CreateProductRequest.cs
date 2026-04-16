namespace Chefia.App.Dtos.Product.Request;

public record CreateProductRequest(
    string Name,
    string? Description,
    decimal Price,
    bool Fractional,
    bool IsAditional,
    Guid? CategoryId
);