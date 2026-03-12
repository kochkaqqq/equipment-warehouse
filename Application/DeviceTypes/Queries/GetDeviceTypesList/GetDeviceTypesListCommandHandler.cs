using Application.Shared.Interfaces;
using Domain.Entities;
using LinqKit;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DeviceTypes.Queries.GetDeviceTypesList
{
    public class GetDeviceTypesListCommandHandler : IRequestHandler<GetDeviceTypesListQuery, List<DeviceType>>
    {
        private readonly IDbContext _context;

        public GetDeviceTypesListCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeviceType>> Handle(GetDeviceTypesListQuery request, CancellationToken cancellationToken)
        {
            var predicate = PredicateBuilder.New<DeviceType>(true);

            if (!string.IsNullOrEmpty(request.Filter.NameSearchText))
            {
                predicate = predicate.And(dt => dt.Name.Value.ToLower().Contains(request.Filter.NameSearchText.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Filter.DescriptionSearchText))
            {
                predicate = predicate.And(dt => dt.Description != null && dt.Description.Value.ToLower().Contains(request.Filter.DescriptionSearchText.ToLower()));
            }
            if (!string.IsNullOrEmpty(request.Filter.CommonSearchText))
            {
                var searchText = request.Filter.CommonSearchText.ToLower();
                predicate = predicate.And(dt =>
                    dt.Name.Value.ToLower().Contains(searchText) ||
                    (dt.Description != null && dt.Description.Value.ToLower().Contains(searchText)));
            }

            List<DeviceType> entities;

            if (request.PageNumber < 0 || request.PageSize < 1)
            {
                throw new ArgumentException();
            }
            else
            {
                entities = await _context.DeviceTypes.AsNoTracking()
                    .Where(predicate)
                    .Skip(request.PageNumber * request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync(cancellationToken);
            }

            return entities;
        }
    }
}
