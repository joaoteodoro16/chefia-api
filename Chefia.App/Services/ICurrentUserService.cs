namespace Chefia.App.Services;

public interface ICurrentUserService
{
    Guid CompanyId { get; }
    Guid UserId { get; }
}
