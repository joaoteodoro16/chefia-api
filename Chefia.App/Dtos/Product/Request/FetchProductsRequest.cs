namespace Chefia.App.Dtos.Product.Request;

public record FetchProductsRequest(
    bool? IsActive,
    string? Name,
    Guid? CategoryId,
    bool? isAditional,
    bool? isFractional
);
