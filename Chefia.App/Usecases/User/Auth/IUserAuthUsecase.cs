using Chefia.App.Dtos.Result;
using Chefia.App.Dtos.User.Request;
using Chefia.App.Dtos.User.Response;
namespace Chefia.App.Usecases.User.Auth;

public interface IUserAuthUsecase
{
    Task<Result<UserAuthResponse>> Execute(UserAuthRequest request);
}
