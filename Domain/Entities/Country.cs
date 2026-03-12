using Domain.Shared;
using Domain.ValueObjects.Country;

namespace Domain.Entities
{
    public class Country : BaseEntity
    {
        public required CountryName Name { get; set; }
        public required CountryCode Code { get; set; }
    }
}
