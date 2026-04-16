using Chefia.App.Common;
using Chefia.App.Dtos.Company.Request;
using Chefia.App.Dtos.Company.Response;
using Chefia.App.Dtos.Result;
using Chefia.App.Mappings;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.Company.Update;

public class UpdateCompanyUsecase : IUpdateCompanyUsecase
{
    private readonly ICompanyRepository _companyRepository;

    public UpdateCompanyUsecase(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task<Result<UpdateCompanyResponse>> Execute(UpdateCompanyRequest request)
    {
        var existingCompany = await _companyRepository.GetByIdAsync(request.Id);

        var companyWithSameCnpj = await _companyRepository.GetByCnpjAsync(request.Cnpj);
        if (companyWithSameCnpj != null && companyWithSameCnpj.Id != request.Id)
        {
            return Result<UpdateCompanyResponse>.Failure(Messages.CompanyCNPJConflict, ErrorCode.Conflict);
        }

        var companyWithSamePhone = await _companyRepository.GetByPhoneAsync(request.Phone);
        if (companyWithSamePhone != null && companyWithSamePhone.Id != request.Id)
        {
            return Result<UpdateCompanyResponse>.Failure(Messages.CompanyPhoneConflict, ErrorCode.Conflict);
        }

        if (existingCompany == null)
        {
            return Result<UpdateCompanyResponse>.Failure(Messages.CompanyNotFound, ErrorCode.NotFound);
        }

        existingCompany.UpdateName(request.Name);
        existingCompany.UpdatePhone(request.Phone);
        existingCompany.UpdateCnpj(request.Cnpj);
        await _companyRepository.UpdateAsync(existingCompany);

        return Result<UpdateCompanyResponse>.Success(CompanyMapping.ToUpdateCompanyResponse(existingCompany), Messages.CompanyUpdated);
    }

}
