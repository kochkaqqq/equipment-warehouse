using Application.Shared.Exceptions;
using Application.Shared.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommandHandler : IRequestHandler<DeleteCountryCommand, Unit>
    {
        private readonly IDbContext _context;

        public DeleteCountryCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCountryCommand request, CancellationToken cancellationToken)
        {
            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == request.Id) 
                ?? throw new EntityNotFoundException(nameof(Country), request.Id.ToString());

            _context.Countries.Remove(country);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
