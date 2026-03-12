using Domain.Entities;
using MediatR;

namespace Application.Nomenclatures.Commands.UpdateNomenclature
{
    public class UpdateNomenclatureCommand : IRequest<Nomenclature>
    {
        public Guid Id { get; set; }
        public string? DeviceImageUrl { get; set; } 
        public string? DeviceImageCaption { get; set; } 
        public Guid? DeviceTypeId { get; set; }
        public Guid? ManufacturerId { get; set; }
        public string? ModelName { get; set; }
        public Guid? CountryId { get; set; }
        public decimal? Price { get; set; }
        public string? Currency { get; set; }
    }
}
