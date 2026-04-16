using Chefia.Domain.Enums;
using Chefia.App.Dtos.User.Response;
using Chefia.App.Dtos.User.Request;

namespace Chefia.App.Mappings;

public class UserMapping
{
    public static CreateUserResponse ToCreateUserResponse(Domain.Entities.User entity)
    {
        return new CreateUserResponse(
            entity.Id,
            entity.Name,
            entity.Email,
            entity.CompanyId,
            entity.Role.ToValue()
        );
    }

    public static Domain.Entities.User ToDomainEntity(CreateUserRequest dto, Guid? companyId)
    {
        return new Domain.Entities.User(
            dto.Name,
            dto.Email,
            dto.Password,
            dto.Role,
            companyId
        );
    }

    public static UserAuthResponse ToUserAuthResponse(Domain.Entities.User entity, string accessToken)
    {
        return new UserAuthResponse(
            entity.Id,
            entity.Name,
            entity.Email,
            entity.CompanyId,
            entity.Role.ToValue(),
            accessToken
        );
    }

    public static UpdateUserResponse ToUpdateUserResponse(Domain.Entities.User entity)
    {
        return new UpdateUserResponse(
            entity.Id,
            entity.Name,
            entity.Email,
            entity.CompanyId,
            entity.Role.ToValue(),
            entity.Active
        );
    }







}
