using Chefia.Domain.Entities;
using Chefia.Domain.Repositories;
using Chefia.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Chefia.Infra.Repositories;

public class CompanyRepository : Repository<Company>, ICompanyRepository
{
    public CompanyRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Company?> GetByCnpjAsync(string cnpj)
    {
        return await _context.Companies.FirstOrDefaultAsync(c => c.Cnpj == cnpj);
    }

    public async Task<Company?> GetByPhoneAsync(string phone)
    {
        return await _context.Companies.FirstOrDefaultAsync(c => c.Phone == phone);
    }
}
