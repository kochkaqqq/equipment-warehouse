using Application.Shared.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DeviceTypes.Queries.GetAllDeviceTypes
{
    public class GetAllDeviceTypesQueryHandler : IRequestHandler<GetAllDeviceTypesQuery, List<DeviceType>>
    {
        private readonly IDbContext _dbContext;

        public GetAllDeviceTypesQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<DeviceType>> Handle(GetAllDeviceTypesQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.DeviceTypes
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
