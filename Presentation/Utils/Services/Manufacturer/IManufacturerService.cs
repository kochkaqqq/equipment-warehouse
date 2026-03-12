using Domain.Entities;
using Domain.Filters;

namespace Presentation.Utils.Services.Manufacturer
{
    public interface IManufacturerService
    {
        Task<List<Domain.Entities.Manufacturer>> GetManufacturersAsync(int page, ManufacturerFilter filter, int pageSize = 15);
        Task<List<Domain.Entities.Manufacturer>> GetManufacturersAsync();
        Task<List<Domain.Entities.Manufacturer>> GetManufacturersByDeviceTypesAsync(ICollection<DeviceType> deviceTypes);
        Task<Guid> CreateManufacturer(string name, string description);
        Task<bool> UpdateManufacturer(Guid id, string? name, string? description);
        Task<bool> DeleteManufacturer(Guid id);
    }
}
