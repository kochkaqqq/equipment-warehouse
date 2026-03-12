using Domain.Entities;
using MediatR;

namespace Application.DeviceTypes.Queries.GetAllDeviceTypes
{
    public class GetAllDeviceTypesQuery : IRequest<List<DeviceType>>
    {
    }
}
