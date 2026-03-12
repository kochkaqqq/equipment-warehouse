using Domain.Entities;
using Domain.Filters;

namespace Presentation.Utils.Services.NomenclatureService
{
    public interface INomenclatureService
    {
        Task<Guid> CreateAsync(Nomenclature nomenclature);
        Task<bool> UpdateAsync(Nomenclature nomenclature);
        Task<bool> DeleteAsync(Guid id);
        Task<List<Nomenclature>> GetNomenclaturesAsync(int page, NomenclatureFilter filter, int pageSize = 15);
    }
}
