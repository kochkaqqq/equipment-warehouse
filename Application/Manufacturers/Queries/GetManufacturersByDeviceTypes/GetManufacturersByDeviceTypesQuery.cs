using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Queries.GetManufacturersByDeviceTypes
{
    public class GetManufacturersByDeviceTypesQuery : IRequest<List<Manufacturer>>
    {
        public ICollection<Guid> DeviceTypeIds { get; set; } = null!;
    }
}
