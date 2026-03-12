using MediatR;
using Domain.Entities;
using Application.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Application.Manufacturers.Queries.GetManufacturersByDeviceTypes
{
    public class GetManufacturersByDeviceTypesQueryHandler : IRequestHandler<GetManufacturersByDeviceTypesQuery, List<Manufacturer>>
    {
        private readonly IDbContext _context;

        public GetManufacturersByDeviceTypesQueryHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<List<Manufacturer>> Handle(GetManufacturersByDeviceTypesQuery request, CancellationToken cancellationToken)
        {
            if (!request.DeviceTypeIds.Any()) 
                return await _context.Manufacturers.AsNoTracking().ToListAsync(cancellationToken);

            var entities = await _context.Nomenclatures
                .AsNoTracking()
                .Include(n => n.Manufacturer)
                .Include(n => n.DeviceType)
                .Where(n => request.DeviceTypeIds.Contains(n.DeviceType.Id))
                .Select(n => n.Manufacturer)
                .ToListAsync(cancellationToken);

            return new HashSet<Manufacturer>(entities).ToList();
        }
    }
}
