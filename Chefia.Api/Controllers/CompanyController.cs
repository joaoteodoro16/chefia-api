using Chefia.Api.Http;
using Chefia.App.Dtos.Company.Response;
using Chefia.App.Usecases.Company.Create;
using Chefia.App.Usecases.Company.GetAll;
using Microsoft.AspNetCore.Mvc;

namespace Chefia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICreateCompanyUsecase _createCompanyUsecase;
    private readonly IGetCompaniesUsecase _getCompaniesUsecase;

    public CompanyController(ICreateCompanyUsecase createCompanyUsecase, IGetCompaniesUsecase getCompaniesUsecase)
    {
        _createCompanyUsecase = createCompanyUsecase;
        _getCompaniesUsecase = getCompaniesUsecase;
    }

    [HttpPost]
    public async Task<ActionResult<ApiResponse<CreateCompanyResponse>>> CreateCompany([FromBody] CreateCompanyRequest request)
    {
        var result = await _createCompanyUsecase.Execute(request);

        return this.ToApiResponse(result, StatusCodes.Status201Created);
    }

    [HttpGet]
    public async Task<ActionResult<ApiResponse<List<GetCompanyResponse>>>> GetCompanies()
    {
        var result = await _getCompaniesUsecase.Execute();

        return this.ToApiResponse(result, StatusCodes.Status200OK);
    }
}
