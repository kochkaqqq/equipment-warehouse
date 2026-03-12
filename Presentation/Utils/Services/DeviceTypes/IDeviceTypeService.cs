using Domain.Entities;
using Domain.Filters;

namespace Presentation.Utils.Services.DeviceTypes
{
    public interface IDeviceTypeService
    {
        Task<List<DeviceType>> GetDeviceTypesAsync(int page, DeviceTypeFilter filter, int pageSize = 15);
        Task<List<DeviceType>> GetDeviceTypesAsync();
        Task<List<DeviceType>> GetDeviceTypesByManufactures(ICollection<Domain.Entities.Manufacturer> manufactures);
        Task<Guid> CreateDeviceType(string name, string description);
        Task<bool> UpdateDeviceType(Guid id, string? name, string? description);
        Task<bool> DeleteDeviceType(Guid id);
    }
}
