using Domain.Entities;
using MediatR;

namespace Application.Nomenclatures.Commands.CreateNomenclature
{
    public class CreateNomenclatureCommand : IRequest<Nomenclature>
    {
        public string DeviceImageUrl { get; set; } = null!;
        public string? DeviceImageCaption { get; set; }
        public Guid DeviceTypeId { get; set; }
        public Guid ManufacturerId { get; set; }
        public string ModelName { get; set; } = null!;
        public Guid CountryId { get; set; }
        public decimal Price { get; set; }
        public string? Currency { get; set; }
    }
}
