using Chefia.Domain.Entities;
using Chefia.Domain.Repositories;
using Chefia.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Chefia.Infra.Repositories;

public class ProductCategoryRepository : Repository<ProductCategory>, IProductCategoryRepository
{
    public ProductCategoryRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<ProductCategory>> FetchProductCategoriesAsync(bool? active, Guid companyId)
    {
        var query = _dbSet.AsQueryable();

        if (active.HasValue)
        {
            query = query.Where(x => x.Active == active.Value);
        }

        query = query.Where(x => x.CompanyId == companyId);

        return await query.ToListAsync();
    }


    public async Task<ProductCategory?> GetByNameAsync(string name, Guid companyId)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.Name == name && x.CompanyId == companyId);
    }



}
