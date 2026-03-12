using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects.Handbook
{
    public class Name : IEquatable<Name>
    {
        private static readonly Regex ValidationRegex = new Regex(
            @"^[\p{L}\p{M}\p{N}\s]{1,70}\z",
            RegexOptions.Singleline | RegexOptions.Compiled
        );

        public Name() { }

        public Name(string value)
        {
            if (!IsValid(value))
                throw new ValidationException(nameof(Name), "Name property must be non-empty, up to 70 letters, withput special symbols.");

            Value = value;
        }

        public string Value { get; init; }

        public static bool IsValid(string value)
        {
            return !string.IsNullOrEmpty(value) && ValidationRegex.IsMatch(value);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Name other)
                return Value == other.Value;

            return false;
        }

        public bool Equals(Name? other)
        {
            if (other is null)
                return false;

            return Value == other.Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(StringComparison.Ordinal);
        }

        public static string ValidationErrorMessage { get; } = "Название должно быть не пустым, до 70 символов и без специальных знаков";
    }
}
