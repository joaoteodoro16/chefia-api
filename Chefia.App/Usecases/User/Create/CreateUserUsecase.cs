using Chefia.App.Common;
using Chefia.App.Dtos.Result;
using Chefia.App.Dtos.User.Request;
using Chefia.App.Dtos.User.Response;
using Chefia.App.Mappings;
using Chefia.Domain.Repositories;
using Chefia.Domain.Services.Security;

namespace Chefia.App.Usecases.User.Create;

public class CreateUserUsecase : ICreateUserUsecase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;

    public CreateUserUsecase(IUserRepository userRepository, IPasswordHasher passwordHasher)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
    }

    public async Task<Result<CreateUserResponse>> Execute(CreateUserRequest request)
    {
        var existingUser = await _userRepository.GetByEmailAsync(request.Email);

        if (existingUser != null)
        {
            return Result<CreateUserResponse>.Failure(Messages.UserEmailConflict, ErrorCode.Conflict);
        }

        var entity = UserMapping.ToDomainEntity(request, null);
        entity.UpdatePassword(null, _passwordHasher.HashPassword(request.Password));

        await _userRepository.AddAsync(entity);

        var response = UserMapping.ToCreateUserResponse(entity);

        return Result<CreateUserResponse>.Success(response, Messages.UserCreated);
    }
}
