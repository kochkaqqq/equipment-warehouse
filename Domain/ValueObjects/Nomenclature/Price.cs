using Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects.Nomenclature
{
    public class Price : IEquatable<Price>
    {
        private static readonly Regex CurrencyCodeRegex = new Regex(
            @"^[A-Z]{3}$",
            RegexOptions.Compiled);

        public decimal Value { get; init; }
        public string Currency { get; init; }

        public Price() { }

        public Price(decimal value, string currency)
        {
            if (!IsPriceValid(value))
                throw new ValidationException(nameof(Price), "Price value must be positive.");

            if (!IsCurrencyValid(currency))
                throw new ValidationException(nameof(Price), "Currency must be a valid ISO 4217 code.");

            Value = value;
            Currency = currency;
        }

        public static bool IsValid(decimal value, string currency)
        {
            return IsPriceValid(value) && IsCurrencyValid(currency);
        }

        public static bool IsPriceValid(decimal value)
        {
            return value > 0;
        }

        public static bool IsCurrencyValid(string currency)
        {
            return CurrencyCodeRegex.IsMatch(currency);
        }

        public override bool Equals(object? obj)
        {
            if (obj is Price other)
                return Value == other.Value && Currency == other.Currency;

            return false;
        }

        public bool Equals(Price? other)
        {
            if (other is null)
                return false;
            return Value == other.Value && Currency == other.Currency;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Currency);
        }

        public static string ValidationErrorMessage { get; } = "Значение суммы должно быть положительное";
    }
}
