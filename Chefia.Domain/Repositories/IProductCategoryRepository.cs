using Chefia.Domain.Entities;

namespace Chefia.Domain.Repositories;

public interface IProductCategoryRepository : IRepository<ProductCategory>
{
    public Task<ProductCategory?> GetByNameAsync(string name, Guid companyId);
    public Task<List<ProductCategory>> FetchProductCategoriesAsync(bool? active, Guid companyId);
}
