namespace Chefia.App.Dtos.User.Request;

public record UpdateUserRequest(
    Guid Id,
    string Name,
    string Email,
    string? OldPassword,
    string? Password,
    int Role,
    bool Active
);
