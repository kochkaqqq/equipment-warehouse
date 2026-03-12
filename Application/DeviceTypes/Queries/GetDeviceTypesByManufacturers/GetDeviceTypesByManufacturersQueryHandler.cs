using Application.Shared.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DeviceTypes.Queries.GetDeviceTypesByManufacturers
{
    public class GetDeviceTypesByManufacturersQueryHandler : IRequestHandler<GetDeviceTypesByManufacturersQuery, List<DeviceType>>
    {
        private readonly IDbContext _context;

        public GetDeviceTypesByManufacturersQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeviceType>> Handle(GetDeviceTypesByManufacturersQuery request, CancellationToken cancellationToken)
        {
            if (!request.ManufacturerIds.Any())
                return await _context.DeviceTypes.AsNoTracking().ToListAsync(cancellationToken);

            var entities = await _context.Nomenclatures
                .AsNoTracking()
                .Include(n => n.DeviceType)
                .Include(n => n.Manufacturer)
                .Where(n => request.ManufacturerIds.Contains(n.Manufacturer.Id))
                .Select(n => n.DeviceType)
                .ToListAsync(cancellationToken);

            return new HashSet<DeviceType>(entities).ToList();
        }
    }
}
