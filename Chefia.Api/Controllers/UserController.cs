using Chefia.Api.Http;
using Chefia.App.Dtos.User.Request;
using Chefia.App.Dtos.User.Response;
using Chefia.App.Usecases.User.Auth;
using Chefia.App.Usecases.User.Create;
using Chefia.App.Usecases.User.Update;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Chefia.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly ICreateUserUsecase _createUserUsecase;
    private readonly IUserAuthUsecase _userAuthUsecase;
    private readonly IUpdateUserUsecase _updateUserUsecase;

    public UserController(ICreateUserUsecase createUserUsecase, IUserAuthUsecase userAuthUsecase, IUpdateUserUsecase updateUserUsecase)
    {
        _createUserUsecase = createUserUsecase;
        _userAuthUsecase = userAuthUsecase;
        _updateUserUsecase = updateUserUsecase;
    }

    [AllowAnonymous]
    [HttpPost]
    public async Task<ActionResult<ApiResponse<CreateUserResponse>>> CreateUser([FromBody] CreateUserRequest request)
    {
        var result = await _createUserUsecase.Execute(request);
        return this.ToApiResponse(result, StatusCodes.Status201Created);
    }

    [AllowAnonymous]
    [HttpPost("auth")]
    public async Task<ActionResult<ApiResponse<UserAuthResponse>>> AuthenticateUser([FromBody] UserAuthRequest request)
    {
        var result = await _userAuthUsecase.Execute(request);
        return this.ToApiResponse(result);
    }

    [HttpPut]
    public async Task<ActionResult<ApiResponse<UpdateUserResponse>>> UpdateUser([FromBody] UpdateUserRequest request)
    {
        var result = await _updateUserUsecase.ExecuteAsync(request);
        return this.ToApiResponse(result);
    }
}
