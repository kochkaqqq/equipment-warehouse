using Application.Shared.Exceptions;
using Application.Shared.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Manufacturers.Commands.DeleteManufacturer
{
    public class DeleteManufacturerCommandHandler : IRequestHandler<DeleteManufacturerCommand, Unit>
    {
        private readonly IDbContext _context;

        public DeleteManufacturerCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Manufacturer), request.Id.ToString());

            _context.Manufacturers.Remove(manufacturer);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
