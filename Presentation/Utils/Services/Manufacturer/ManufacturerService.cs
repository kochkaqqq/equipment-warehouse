using Domain.Entities;
using Domain.Filters;
using Domain.ValueObjects.Handbook;
using Presentation.Utils.ApiClient;

namespace Presentation.Utils.Services.Manufacturer
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IApiClient _apiClient;

        public ManufacturerService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Guid> CreateManufacturer(string name, string description)
        {
            var content = JsonContent.Create(new
            {
                Name = name,
                Description = description
            });

            return await _apiClient.CreateEntityAsync("api/manufacturers", content);
        }

        public async Task<bool> DeleteManufacturer(Guid id)
        {
            return await _apiClient.DeleteAsync("api/manufacturers", id);
        }

        public async Task<List<Domain.Entities.Manufacturer>> GetManufacturersAsync(int page, ManufacturerFilter filter, int pageSize = 15)
        {
            var content = JsonContent.Create(new
            {
                PageNumber = page,
                PageSize = pageSize,
                Filter = filter,
            });

            return await _apiClient.PostAsync<List<Domain.Entities.Manufacturer>> ("api/manufacturers/query", content);
        }

        public async Task<List<Domain.Entities.Manufacturer>> GetManufacturersAsync()
        {
            var res = await _apiClient.GetAsync<List<Domain.Entities.Manufacturer>>("api/manufacturers");
            return res;
        }

        public async Task<List<Domain.Entities.Manufacturer>> GetManufacturersByDeviceTypesAsync(ICollection<DeviceType> deviceTypes)
        {
            var content = JsonContent.Create(new
            {
                DeviceTypeIds = deviceTypes.Select(dt => dt.Id)
            });
            return await _apiClient.PostAsync<List<Domain.Entities.Manufacturer>>("api/manufacturers/get-by-device-types", content);
        }

        public async Task<bool> UpdateManufacturer(Guid id, string? name, string? description)
        {
            var content = JsonContent.Create(new
            {
                Id = id,
                Name = name,
                Description = description
            });

            return await _apiClient.PutAsync("api/manufacturers", content);
        }
    }
}
