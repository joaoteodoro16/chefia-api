using Chefia.App.Dtos.Result;
using Chefia.App.Dtos.User.Request;
using Chefia.App.Dtos.User.Response;

namespace Chefia.App.Usecases.User.Update;

public interface IUpdateUserUsecase
{
    Task<Result<UpdateUserResponse>> ExecuteAsync(UpdateUserRequest request);
}

