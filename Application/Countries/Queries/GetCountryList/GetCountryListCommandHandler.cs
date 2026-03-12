using Application.Shared.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Countries.Queries.GetCountryList
{
    public class GetCountryListCommandHandler : IRequestHandler<GetCountryListCommand, List<Country>>
    {
        private readonly IDbContext _dbContext;

        public GetCountryListCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Country>> Handle(GetCountryListCommand request, CancellationToken cancellationToken)
        {
            return await _dbContext.Countries.ToListAsync(cancellationToken);
        }
    }
}
