using Domain.Filters.CustomFilters;

namespace Domain.Filters
{
    public class NomenclatureFilter
    {
        public ICollection<Guid>? DeviceTypeIds { get; set; }
        public ICollection<Guid>? ManufacturerIds { get; set; }
        public string? SearchText { get; set; }
        public ICollection<Guid>? CountryIds { get; set; }
        public PriceFilter? PriceFilter { get; set; }
    }
}
