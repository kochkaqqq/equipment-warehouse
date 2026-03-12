using Amazon.S3.Model;
using Domain.Entities;
using Domain.Filters;
using Domain.ValueObjects.Nomenclature;
using Presentation.Utils.ApiClient;

namespace Presentation.Utils.Services.NomenclatureService
{
    public class NomenclatureService : INomenclatureService
    {
        private readonly IApiClient _apiClient;
        
        public NomenclatureService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<Guid> CreateAsync(Nomenclature nomenclature)
        {
            var content = JsonContent.Create(new
            {
                DeviceImageUrl = nomenclature.DeviceImage.Url,
                DeviceImageCaption = nomenclature.DeviceImage.Caption,
                DeviceTypeId = nomenclature.DeviceType.Id,
                ManufacturerId = nomenclature.Manufacturer.Id,
                ModelName = nomenclature.ModelName.Value,
                CountryId = nomenclature.Country.Id,
                Price = nomenclature.Price.Value,
                Currency = nomenclature.Price.Currency
            });
            var res = await _apiClient.CreateEntityAsync("api/nomenclatures", content);
            return res;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            return await _apiClient.DeleteAsync("api/nomenclatures", id);
        }

        public Task<List<Nomenclature>> GetNomenclaturesAsync(int page, NomenclatureFilter filter, int pageSize = 15)
        {
            var content = JsonContent.Create(new
            {
                PageNumber = page,
                PageSize = pageSize,
                Filter = filter,
            });
            return _apiClient.PostAsync<List<Nomenclature>>("api/nomenclatures/query", content);
        }

        public Task<bool> UpdateAsync(Nomenclature nomenclature)
        {
            var content = JsonContent.Create(new
            {
                Id = nomenclature.Id,
                DeviceImageUrl = nomenclature.DeviceImage.Url,
                DeviceImageCaption = nomenclature.DeviceImage.Caption,
                DeviceTypeId = nomenclature.DeviceType.Id,
                ManufacturerId = nomenclature.Manufacturer.Id,
                ModelName = nomenclature.ModelName.Value,
                CountryId = nomenclature.Country.Id,
                Price = nomenclature.Price.Value,
                Currency = nomenclature.Price.Currency
            });

            return _apiClient.PutAsync("api/nomenclatures", content);
        }
    }
}
