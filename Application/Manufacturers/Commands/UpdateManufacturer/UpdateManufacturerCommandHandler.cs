using Application.Shared.Exceptions;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.ValueObjects.Handbook;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Manufacturers.Commands.UpdateManufacturer
{
    public class UpdateManufacturerCommandHandler : IRequestHandler<UpdateManufacturerCommand, Unit>
    {
        private readonly IDbContext _context;

        public UpdateManufacturerCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Manufacturer), request.Id.ToString());

            if (!string.IsNullOrEmpty(request.Name))
            {
                manufacturer.Name = new Name(request.Name);
            }

            if (request.Description != null)
            {
                manufacturer.Description = new Description(request.Description);
            }

            manufacturer.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
