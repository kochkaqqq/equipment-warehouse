using Domain.Exceptions;
using Domain.ValueObjects.Country;
using System.Text.RegularExpressions;

namespace Domain.ValueObjects.Nomenclature
{
    public class DeviceImage : IEquatable<DeviceImage>
    {
        private static readonly Regex ImageUrlRegex = new Regex(
            @"^https?:\/\/.*\.(?:png|jpg|jpeg|gif|bmp|webp|svg)(?:\?.*)?$",
            RegexOptions.IgnoreCase | RegexOptions.Compiled);

        private static readonly Regex CaptionRegex = new Regex(
            @"^[\p{L}\p{M}\p{N}\s\.,!?-]{0,200}$",
            RegexOptions.Compiled);

        public string Url { get; init; }
        public string Caption { get; init; }

        public DeviceImage() { }

        public DeviceImage(string url, string caption)
        {
            if (!IsValidUrl(url))
                throw new ValidationException(nameof(DeviceImage), "Invalid URL format.");

            if (!IsValidCaption(caption))
                throw new ValidationException(nameof(DeviceImage), "Invalid caption format.");

            Url = url;
            Caption = caption ?? string.Empty;
        }

        public static bool IsValid(string url, string caption)
        {
            return IsValidUrl(url) && IsValidCaption(caption);
        }

        public static bool IsValidUrl(string url) => ImageUrlRegex.IsMatch(url);
        
        public static bool IsValidCaption(string caption) => CaptionRegex.IsMatch(caption);

        public override bool Equals(object? obj)
        {
            if (obj is not DeviceImage other) return false;
            return Url == other.Url && Caption == other.Caption;
        }

        public override int GetHashCode() => HashCode.Combine(Url, Caption);

        public bool Equals(DeviceImage? other)
        {
            if (other == null)
                return false;

            return Caption == other.Caption && Url == other.Url;
        }
    }
}
