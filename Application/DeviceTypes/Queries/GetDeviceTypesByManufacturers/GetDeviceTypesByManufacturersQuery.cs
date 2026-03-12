using Domain.Entities;
using MediatR;

namespace Application.DeviceTypes.Queries.GetDeviceTypesByManufacturers
{
    public class GetDeviceTypesByManufacturersQuery : IRequest<List<DeviceType>>
    {
        public ICollection<Guid> ManufacturerIds { get; set; } = null!;
    }
}
