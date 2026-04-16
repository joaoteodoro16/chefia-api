namespace Chefia.App.Dtos.Product.Response;

public record UpdateProductResponse(
    Guid Id,
    string Name,
    string? Description,
    decimal Price,
    bool Fractional,
    Guid CompanyId,
    bool IsAditional,
    Guid? CategoryId
);
