using Application.Shared.Exceptions;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.Exceptions;
using Domain.ValueObjects.Country;
using MediatR;

namespace Application.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommandHandler : IRequestHandler<UpdateCountryCommand, Guid>
    {
        private readonly IDbContext _context;

        public UpdateCountryCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == request.Id)
                ?? throw new EntityNotFoundException(nameof(Country), request.Id.ToString());

            if (!string.IsNullOrEmpty(request.Name))
                country.Name = new CountryName(request.Name);
            if (!string.IsNullOrEmpty(request.Code))
                country.Code = new CountryCode(request.Code);

            await _context.SaveChangesAsync(cancellationToken);
            return country.Id;
        }
    }
}
