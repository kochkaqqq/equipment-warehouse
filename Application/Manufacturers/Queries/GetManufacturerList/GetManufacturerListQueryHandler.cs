using Application.Shared.Interfaces;
using Domain.Entities;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Manufacturers.Queries.GetManufacturerList
{
    public class GetManufacturerListQueryHandler : IRequestHandler<GetManufacturerListQuery, List<Manufacturer>>
    {
        private readonly IDbContext _context;

        public GetManufacturerListQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<List<Manufacturer>> Handle(GetManufacturerListQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.New<Manufacturer>(true);

            if (!string.IsNullOrEmpty(request.Filter.NameSearchText))
            {
                predicate = predicate.And(m => m.Name.Value.ToLower().Contains(request.Filter.NameSearchText.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.Filter.DescriptionSearchText))
            {
                predicate = predicate.And(m => m.Description != null && m.Description.Value.ToLower().Contains(request.Filter.DescriptionSearchText.ToLower()));
            }

            if (!string.IsNullOrEmpty(request.Filter.CommonSearchText))
            {
                var searchText = request.Filter.CommonSearchText.ToLower();
                predicate = predicate.And(m =>
                    m.Name.Value.ToLower().Contains(searchText) ||
                    (m.Description != null && m.Description.Value.ToLower().Contains(searchText)));
            }

            var entities = await _context.Manufacturers
                .Where(predicate)
                .Skip(request.PageNumber * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            return entities;
        }
    }
}
