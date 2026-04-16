namespace Chefia.Domain.Enums;

public enum OperatorRole
{
    Admin = 1,
    Operator = 2
}

public static class OperatorRoleExtensions
{
    public static OperatorRole ToOperatorRole(this int value)
    {
        if (!Enum.IsDefined(typeof(OperatorRole), value))
        {
            throw new ArgumentException("Role inválida.", nameof(value));
        }

        return (OperatorRole)value;
    }

    public static int ToValue(this OperatorRole role)
    {
        return (int)role;
    }
}
