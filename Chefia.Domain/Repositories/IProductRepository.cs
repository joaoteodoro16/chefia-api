using Chefia.Domain.Entities;

namespace Chefia.Domain.Repositories;

public interface IProductRepository : IRepository<Product>
{
    public Task<Product?> GetByNameAsync(string name);
    public Task<List<Product>> FetchProductsByCompanyIdAsync(
        bool? IsActive,
        string? Name,
        Guid? CategoryId,
        bool? isAditional,
        bool? isFractional,
        Guid companyId
    );

}
