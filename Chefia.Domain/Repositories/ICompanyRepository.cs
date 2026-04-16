using Chefia.Domain.Entities;

namespace Chefia.Domain.Repositories;

public interface ICompanyRepository : IRepository<Company>
{
    public Task<Company?> GetByCnpjAsync(string cnpj);
    public Task<Company?> GetByPhoneAsync(string phone);
}
