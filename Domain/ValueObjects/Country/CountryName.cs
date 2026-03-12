using Domain.Exceptions;

namespace Domain.ValueObjects.Country
{
    public class CountryName : IEquatable<CountryCode>
    {
        public CountryName() { }

        public CountryName(string value)
        {
            if (!IsValid(value))
                throw new ValidationException(nameof(CountryName), "Country name must be non-empty, up to 70 characters, and contain only letters and spaces.");
            Value = value;
        }

        public string Value { get; init; }

        public static bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && value.Length <= 70 && value.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
        }

        public override bool Equals(object? obj)
        {
            if (obj is CountryName other)
                return Value == other.Value;
            return false;
        }

        public bool Equals(CountryCode? other)
        {
            if (other == null)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(StringComparison.Ordinal);
        }
    }
}
