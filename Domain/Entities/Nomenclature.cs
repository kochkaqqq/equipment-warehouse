using Domain.Shared;
using Domain.ValueObjects.Nomenclature;

namespace Domain.Entities
{
    public class Nomenclature : BaseEntity
    {
        public required DeviceImage DeviceImage { get; set; }
        public required DeviceType DeviceType { get; set; }
        public required Manufacturer Manufacturer { get; set; }
        public required ModelName ModelName { get; set; }
        public required Country Country { get; set; }
        public required Price Price { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
