using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.ValueObjects.Country;
using MediatR;

namespace Application.Countries.Commands.CreateCountry
{
    public class CreateCountryCommandHandler : IRequestHandler<CreateCountryCommand, Guid>
    {
        private readonly IDbContext _context;
        public CreateCountryCommandHandler(IDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
        {
            var countryName = new CountryName(request.Name);
            var countryCode = new CountryCode(request.Code);

            var country = new Country
            {
                Id = Guid.NewGuid(),
                Name = countryName,
                Code = countryCode
            };

            await _context.Countries.AddAsync(country, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return country.Id;
        }
    }
}
