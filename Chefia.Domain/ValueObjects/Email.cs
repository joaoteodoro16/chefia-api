namespace Chefia.Domain.ValueObjects;

public sealed class Email : IEquatable<Email>
{
    public string Value { get; }

    public string Formatted => Format(Value);

    public Email(string value)
    {
        Value = Normalize(value);
    }

    public override string ToString()
    {
        return Formatted;
    }

    public string ToUnformattedString()
    {
        return Value;
    }

    public static string Format(string value)
    {
        return Normalize(value);
    }

    public static string Normalize(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Email deve ser informado.", nameof(value));
        }

        var normalized = value.Trim().ToLowerInvariant();

        if (normalized.Length > 254)
        {
            throw new ArgumentException("Email invalido.", nameof(value));
        }

        if (!IsValid(normalized))
        {
            throw new ArgumentException("Email invalido.", nameof(value));
        }

        return normalized;
    }

    public bool Equals(Email? other)
    {
        if (other is null)
        {
            return false;
        }

        return Value == other.Value;
    }

    public override bool Equals(object? obj)
    {
        return obj is Email other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public static implicit operator string(Email email)
    {
        return email.Value;
    }

    private static bool IsValid(string value)
    {
        try
        {
            var address = new System.Net.Mail.MailAddress(value);
            if (!string.Equals(address.Address, value, StringComparison.OrdinalIgnoreCase))
            {
                return false;
            }

            var parts = value.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }

            var localPart = parts[0];
            var domainPart = parts[1];

            if (localPart.Length == 0 || localPart.Length > 64)
            {
                return false;
            }

            if (domainPart.Length == 0 || domainPart.StartsWith('.') || domainPart.EndsWith('.'))
            {
                return false;
            }

            if (!domainPart.Contains('.'))
            {
                return false;
            }

            return true;
        }
        catch (FormatException)
        {
            return false;
        }
    }
}
