using Application.Shared.Interfaces;
using Domain.Entities;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Nomenclatures.Queries.GetNomenclaturesList
{
    public class GetNomenclatureListQueryHandler : IRequestHandler<GetNomenclatureListQuery, List<Nomenclature>>
    {
        private readonly IDbContext _context;

        public GetNomenclatureListQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<List<Nomenclature>> Handle(GetNomenclatureListQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.New<Nomenclature>(true);

            if (request.Filter.DeviceTypeIds != null && request.Filter.DeviceTypeIds.Count > 0)
                predicate = predicate.And(n => request.Filter.DeviceTypeIds.Contains(n.DeviceType.Id));

            if (request.Filter.ManufacturerIds != null && request.Filter.ManufacturerIds.Count > 0)
                predicate = predicate.And(n => request.Filter.ManufacturerIds.Contains(n.Manufacturer.Id));

            if (request.Filter.CountryIds != null && request.Filter.CountryIds.Count > 0)
                predicate = predicate.And(n => request.Filter.CountryIds.Contains(n.Country.Id));

            if (!string.IsNullOrEmpty(request.Filter.SearchText))
            {
                var searchText = request.Filter.SearchText.ToLower();
                predicate = predicate.And(n => n.ModelName.Value.ToLower().Contains(searchText)
                    || n.Manufacturer.Name.Value.ToLower().Contains(searchText)
                    || n.DeviceType.Name.Value.ToLower().Contains(searchText));
            }

            if (request.Filter.PriceFilter != null)
                predicate = predicate.And(n => n.Price.Value >= (request.Filter.PriceFilter.MinPrice ?? decimal.MinValue)
                    && n.Price.Value <= (request.Filter.PriceFilter.MaxPrice ?? decimal.MaxValue));

            return await _context.Nomenclatures
                .AsNoTracking()
                .Include(n => n.DeviceType)
                .Include(n => n.Manufacturer)
                .Include(n => n.Country)
                .Where(predicate)
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);
        }
    }
}
