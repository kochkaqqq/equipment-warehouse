using Domain.Entities;

namespace Presentation.Utils.Services.Contries
{
    public interface ICountryService
    {
        Task<List<Country>> GetListAsync();
        Task<Guid> CreateCountryAsync(string name, string countryCode);
    }
}
