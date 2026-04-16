namespace Chefia.App.Dtos.User.Response;

public record CreateUserResponse(
    Guid Id,
    string Name,
    string Email,
    Guid? CompanyId,
    int Role
);
