using Domain.Entities;
using Domain.Filters;
using MediatR;

namespace Application.DeviceTypes.Queries.GetDeviceTypesList
{
    public class GetDeviceTypesListQuery : IRequest<List<DeviceType>>
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 15;
        public DeviceTypeFilter Filter { get; set; } = new();
    }
}
