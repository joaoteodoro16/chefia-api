namespace Chefia.Domain.ValueObjects;

public sealed class Phone : IEquatable<Phone>
{
	public string Value { get; }

	public string Formatted => Format(Value);

	public Phone(string value)
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
		var digits = Normalize(value);

		return $"({digits[..2]}) {digits.Substring(2, 5)}-{digits.Substring(7, 4)}";
	}

	public static string Normalize(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new ArgumentException("Telefone deve ser informado.", nameof(value));
		}

		var digits = new string(value.Where(char.IsDigit).ToArray());

		if (digits.Length != 11)
		{
			throw new ArgumentException("Telefone brasileiro deve conter 11 digitos.", nameof(value));
		}

		var ddd = int.Parse(digits[..2]);
		if (ddd < 11 || ddd > 99)
		{
			throw new ArgumentException("DDD invalido para telefone brasileiro.", nameof(value));
		}

		if (digits[2] != '9')
		{
			throw new ArgumentException("Celular brasileiro com 11 digitos deve iniciar com 9 apos o DDD.", nameof(value));
		}

		return digits;
	}

	public bool Equals(Phone? other)
	{
		if (other is null)
		{
			return false;
		}

		return Value == other.Value;
	}

	public override bool Equals(object? obj)
	{
		return obj is Phone other && Equals(other);
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public static implicit operator string(Phone phone)
	{
		return phone.Value;
	}
}
