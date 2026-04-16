namespace Chefia.App.Dtos.User.Response;

public record UpdateUserResponse(
    Guid Id,
    string Name,
    string Email,
    Guid? CompanyId,
    int Role,
    bool Active
);
