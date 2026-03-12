using Application.Shared.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Manufacturers.Queries.GetAllManufactures
{
    public class GetAllManufacturersQueryHandler : IRequestHandler<GetAllManufacturersQuery, List<Manufacturer>>
    {
        private readonly IDbContext _dbContext;

        public GetAllManufacturersQueryHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Manufacturer>> Handle(GetAllManufacturersQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Manufacturers
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}
