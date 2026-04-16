namespace Chefia.App.Dtos.User.Response;

public record UserAuthResponse(
    Guid Id,
    string Name,
    string Email,
    Guid? CompanyId,
    int Role,
    string AccessToken
);
