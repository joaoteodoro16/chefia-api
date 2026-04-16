using Chefia.App.Common;
using Chefia.App.Dtos.Result;
using Chefia.App.Dtos.User.Request;
using Chefia.App.Dtos.User.Response;
using Chefia.App.Mappings;
using Chefia.Domain.Repositories;

namespace Chefia.App.Usecases.User.Update;

public class UpdateUserUsecase : IUpdateUserUsecase
{

    private readonly IUserRepository _userRepository;

    public UpdateUserUsecase(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<UpdateUserResponse>> ExecuteAsync(UpdateUserRequest request)
    {
        //Informação vai vim do accessToken (Provisório enquanto nao implemento o jwt)
        //Guid requestedId = Guid.Parse("67ffe347-d6e1-4e29-8fe4-9e65e5b63505"); //ADMIN
        Guid requestedId = Guid.Parse("7909cf4d-69d3-42fa-baac-edffbb3798cf"); //SEM ADMIN


        //Qual usuário vai ser atualizado
        var updatedUser = await _userRepository.GetByIdAsync(request.Id);

        //Usuário que ta solicitando a atualização
        var requester = await _userRepository.GetByIdAsync(requestedId);

        if (updatedUser == null || requester == null)
            return Result<UpdateUserResponse>.Failure(Messages.UserNotFound, ErrorCode.NotFound);

        if (request.OldPassword != null && request.Password != null)
            updatedUser.UpdatePassword(request.OldPassword, request.Password);

        updatedUser.UpdateName(request.Name);
        updatedUser.UpdateRole(request.Role, requester);
        updatedUser.UpdateStatus(request.Active);

        await _userRepository.UpdateAsync(updatedUser);
        return Result<UpdateUserResponse>.Success(UserMapping.ToUpdateUserResponse(updatedUser), Messages.UserUpdated);
    }
}
