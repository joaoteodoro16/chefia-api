namespace Chefia.App.Dtos.User.Request;

public record CreateUserRequest(
    string Name,
    string Email,
    string Password,
    int Role
);
