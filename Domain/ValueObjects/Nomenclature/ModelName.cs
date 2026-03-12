using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects.Nomenclature
{
    public class ModelName : IEquatable<ModelName>
    {
        private static readonly Regex ValidationRegex = new Regex(
            @"^[\p{L}\p{M}\p{N}\s\.]{1,100}\z",
            RegexOptions.Singleline | RegexOptions.Compiled);

        public string Value { get; init; }

        public ModelName() { }

        public ModelName(string name)
        {
            if (!IsValid(name))
                throw new ValidationException(nameof(ModelName), "Model name must be 1-100 characters long and can only contain letters, numbers, spaces.");

            Value = name;
        }

        public static bool IsValid(string value)
        {
            return !string.IsNullOrWhiteSpace(value) && ValidationRegex.IsMatch(value);
        }

        public bool Equals(ModelName? other)
        {
            if (other == null)
                return false;

            return Value == other.Value;
        }

        override public bool Equals(object? obj)
        {
            if (obj is ModelName other)
                return Value == other.Value;
            return false;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode(StringComparison.Ordinal);
        }

        public static string ValidationErrorMessage { get; } = "Название модели должно быть не пустым, короче 100 и не содержать специальных символов.";
    }
}
