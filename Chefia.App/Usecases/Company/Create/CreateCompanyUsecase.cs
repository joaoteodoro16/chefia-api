using Chefia.App.Common;
using Chefia.App.Dtos.Company.Response;
using Chefia.App.Dtos.Result;
using Chefia.App.Mappings;
using Chefia.App.Usecases.Company.Create;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.Company;

public class CreateCompanyUsecase : ICreateCompanyUsecase
{
    private readonly ICompanyRepository _companyRepository;
    private readonly IUserRepository _userRepository;

    public CreateCompanyUsecase(ICompanyRepository companyRepository, IUserRepository userRepository)
    {
        _companyRepository = companyRepository;
        _userRepository = userRepository;
    }

    public async Task<Result<CreateCompanyResponse>> Execute(CreateCompanyRequest request)
    {
        var user = await _userRepository.GetByIdAsync(request.InitialUserId);

        if (user == null)
        {
            return Result<CreateCompanyResponse>.Failure(Messages.UserNotFound, ErrorCode.NotFound);
        }

        if (user.CompanyId != null)
        {
            return Result<CreateCompanyResponse>.Failure(Messages.UserAlreadyInCompany, ErrorCode.BadRequest);
        }

        var company = CompanyMapping.ToCompany(request);

        var existingCompany = await _companyRepository.GetByCnpjAsync(company.Cnpj);

        if (existingCompany != null)
        {
            return Result<CreateCompanyResponse>.Failure(Messages.CompanyCNPJConflict, ErrorCode.Conflict);
        }

        existingCompany = await _companyRepository.GetByPhoneAsync(company.Phone);

        if (existingCompany != null)
        {
            return Result<CreateCompanyResponse>.Failure(Messages.CompanyPhoneConflict, ErrorCode.Conflict);
        }

        await _companyRepository.AddAsync(company);

        user.UpdateCompanyId(company.Id);
        await _userRepository.UpdateAsync(user);

        var response = CompanyMapping.ToCreateCompanyResponse(company);
        return Result<CreateCompanyResponse>.Success(response, Messages.CompanyCreated);
    }
}
