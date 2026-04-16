using Chefia.App.Common;
using Chefia.App.Dtos.Result;
using Chefia.App.Dtos.User.Request;
using Chefia.App.Dtos.User.Response;
using Chefia.App.Mappings;
using Chefia.Domain.Repositories;
using Chefia.Domain.Services.Security;

namespace Chefia.App.Usecases.User.Auth;

public class UserAuthUsecase : IUserAuthUsecase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _tokenService;

    public UserAuthUsecase(IUserRepository userRepository, IPasswordHasher passwordHasher, IJwtTokenService tokenService)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _tokenService = tokenService;
    }

    public async Task<Result<UserAuthResponse>> Execute(UserAuthRequest request)
    {
        var entity = await _userRepository.GetByEmailAsync(request.Email);

        if (entity == null || !_passwordHasher.VerifyPassword(request.Password, entity.Password))
        {
            return Result<UserAuthResponse>.Failure(Messages.UserAuthFailed, ErrorCode.Unauthorized);
        }

        var token = _tokenService.GenerateToken(entity);

        var response = UserMapping.ToUserAuthResponse(entity, accessToken: token);
        return Result<UserAuthResponse>.Success(response, Messages.UserAuthSuccess);
    }
}
