namespace Chefia.Domain.ValueObjects;

public sealed class Cnpj : IEquatable<Cnpj>
{
	public string Value { get; }

	public string Formatted => Format(Value);

	public Cnpj(string value)
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

		return $"{digits[..2]}.{digits.Substring(2, 3)}.{digits.Substring(5, 3)}/{digits.Substring(8, 4)}-{digits.Substring(12, 2)}";
	}

	public static string Normalize(string value)
	{
		if (string.IsNullOrWhiteSpace(value))
		{
			throw new ArgumentException("CNPJ deve ser informado.", nameof(value));
		}

		var digits = new string(value.Where(char.IsDigit).ToArray());

		if (digits.Length != 14)
		{
			throw new ArgumentException("CNPJ deve conter 14 digitos.", nameof(value));
		}

		if (digits.Distinct().Count() == 1)
		{
			throw new ArgumentException("CNPJ invalido.", nameof(value));
		}

		if (!HasValidCheckDigits(digits))
		{
			throw new ArgumentException("CNPJ invalido.", nameof(value));
		}

		return digits;
	}

	public bool Equals(Cnpj? other)
	{
		if (other is null)
		{
			return false;
		}

		return Value == other.Value;
	}

	public override bool Equals(object? obj)
	{
		return obj is Cnpj other && Equals(other);
	}

	public override int GetHashCode()
	{
		return Value.GetHashCode();
	}

	public static implicit operator string(Cnpj cnpj)
	{
		return cnpj.Value;
	}

	private static bool HasValidCheckDigits(string digits)
	{
		var firstDigit = CalculateCheckDigit(digits[..12], new[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });
		var secondDigit = CalculateCheckDigit(digits[..12] + firstDigit, new[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 });

		return digits[12] - '0' == firstDigit && digits[13] - '0' == secondDigit;
	}

	private static int CalculateCheckDigit(string digits, int[] weights)
	{
		var sum = 0;

		for (var index = 0; index < weights.Length; index++)
		{
			sum += (digits[index] - '0') * weights[index];
		}

		var remainder = sum % 11;

		return remainder < 2 ? 0 : 11 - remainder;
	}
}
