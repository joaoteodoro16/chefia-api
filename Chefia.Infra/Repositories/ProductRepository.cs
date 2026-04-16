using Chefia.Domain.Entities;
using Chefia.Domain.Repositories;
using Chefia.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Chefia.Infra.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<List<Product>> FetchProductsByCompanyIdAsync(bool? IsActive, string? Name, Guid? CategoryId, bool? isAditional, bool? isFractional, Guid companyId)
    {
        var query = _dbSet.AsQueryable().Include(p => p.ProductCategory).Where(p => p.CompanyId == companyId);

        if (IsActive.HasValue)
            query = query.Where(p => p.Active == IsActive.Value);

        if (!string.IsNullOrEmpty(Name))
            query = query.Where(p => p.Name.Contains(Name));

        if (CategoryId.HasValue)
            query = query.Where(p => p.ProductCategoryId == CategoryId.Value);

        if (isAditional.HasValue)
            query = query.Where(p => p.IsAditional == isAditional.Value);

        if (isFractional.HasValue)
            query = query.Where(p => p.Fractional == isFractional.Value);

        return await query.ToListAsync();
    }


    public async Task<Product?> GetByNameAsync(string name)
    {
        return await _dbSet.FirstOrDefaultAsync(p => p.Name == name);
    }
}
