using Domain.Exceptions;
using Domain.ValueObjects.Handbook;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects.Country
{
    public class CountryCode : IEquatable<CountryCode>
    {
        private static readonly Regex CountryCodeRegex = new Regex(
            @"^[A-Z]{2}$",
            RegexOptions.Compiled);

        public CountryCode() { }

        public CountryCode(string value)
        {
            if (!IsValid(value))
                throw new ValidationException(nameof(CountryCode), "Country code must be exactly 2 uppercase letters.");
            Value = value;
        }

        public string Value { get; init; }

        public static bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && CountryCodeRegex.IsMatch(value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Name other)
                return Value == other.Value;

            return false;
        }

        public bool Equals(CountryCode? other)
        {
            if (other is null)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(StringComparison.Ordinal);
        }
    }
}
