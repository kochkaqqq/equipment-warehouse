using Domain.Entities;
using Domain.Filters;
using MediatR;

namespace Application.Nomenclatures.Queries.GetNomenclaturesList
{
    public class GetNomenclatureListQuery : IRequest<List<Nomenclature>>
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 15;
        public NomenclatureFilter Filter { get; set; } = new();
    }
}
