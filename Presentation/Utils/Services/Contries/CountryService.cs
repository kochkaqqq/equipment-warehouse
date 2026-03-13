using Domain.Entities;
using Presentation.Utils.ApiClient;

namespace Presentation.Utils.Services.Contries
{
    /*
     *  Здесь правильнее было бы использовать прямое обращение к бд (через запросы медиатр)
     *  Так как клиент и сервер находятся в одном проекте
     *  
     *  Такое решение было принято с расчетом на то что позже UI будет вынесен в отдельный проект
     */
    public class CountryService : ICountryService
    {
        private readonly IApiClient _apiClient;

        public CountryService(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public Task<Guid> CreateCountryAsync(string name, string countryCode)
        {
            var content = JsonContent.Create(new
            {
                Name = name,
                Code = countryCode
            });

            return _apiClient.CreateEntityAsync("api/countries", content);
        }

        public Task<List<Country>> GetListAsync()
        {
            return _apiClient.GetAsync<List<Country>>("api/countries");
        }
    }
}
