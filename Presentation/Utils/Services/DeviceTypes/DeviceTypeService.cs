using Domain.Entities;
using Domain.Filters;
using Presentation.Utils.ApiClient;

namespace Presentation.Utils.Services.DeviceTypes
{
    public class DeviceTypeService : IDeviceTypeService
    {
        private readonly IApiClient _apiClient;

        public DeviceTypeService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Guid> CreateDeviceType(string name, string description)
        {
            var content = JsonContent.Create(new
            {
                Name = name,
                Description = description
            });

            return await _apiClient.CreateEntityAsync("api/device-types", content);
        }

        public async Task<bool> DeleteDeviceType(Guid id)
        {
            return await _apiClient.DeleteAsync("api/device-types", id);
        }

        public async Task<List<DeviceType>> GetDeviceTypesByManufactures(ICollection<Domain.Entities.Manufacturer> manufactures)
        {
            var content = JsonContent.Create(new
            {
                ManufacturerIds = manufactures.Select(m => m.Id)
            });
            return await _apiClient.PostAsync<List<DeviceType>>("api/device-types/get-by-manufacturers", content);
        }

        public async Task<List<DeviceType>> GetDeviceTypesAsync(int page, DeviceTypeFilter filter, int pageSize = 15)
        {
            var content = JsonContent.Create(new
            {
                PageNumber = page,
                PageSize = pageSize,
                Filter = filter
            });

            return await _apiClient.PostAsync<List<DeviceType>>("api/device-types/query", content);
        }

        public async Task<List<DeviceType>> GetDeviceTypesAsync()
        {
            var res = await _apiClient.GetAsync<List<DeviceType>>("api/device-types");
            return res;
        }

        public Task<bool> UpdateDeviceType(Guid id, string? name, string? description)
        {
            var content = JsonContent.Create(new
            {
                Id = id,
                Name = name,
                Description = description
            });

            return _apiClient.PutAsync($"api/device-types", content);
        }
    }
}
