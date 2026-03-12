using Domain.Exceptions;
using Domain.ValueObjects.Country;

namespace Domain.ValueObjects.Handbook
{
    public class Description : IEquatable<CountryCode>
    {
        public Description() { }
        public Description(string value)
        {
            if (!IsValid(value))
                throw new ValidationException(nameof(Description), "Description length must be up to 512 symbols.");
            Value = value;
        }

        public string Value { get; init; }

        public static bool IsValid(string value)
        {
            return value.Length <= 511;
        }

        public override bool Equals(object? obj)
        {
            if (obj is Description other)
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

        public static string ValidationErrorMessage { get; } = "Описание должно быть короче 512 символов.";
    }
}
