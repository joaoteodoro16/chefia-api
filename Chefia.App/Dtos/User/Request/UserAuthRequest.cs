namespace Chefia.App.Dtos.User.Request;

public record UserAuthRequest(
    string Email,
    string Password
);
