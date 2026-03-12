using Application.Shared.Exceptions;
using Application.Shared.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DeviceTypes.Commands.DeleteDeviceType
{
    public class DeleteDeviceTypeCommandHandler : IRequestHandler<DeleteDeviceTypeCommand, Unit>
    {
        private readonly IDbContext _context;

        public DeleteDeviceTypeCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteDeviceTypeCommand request, CancellationToken cancellationToken)
        {
            var deviceType = await _context.DeviceTypes.FirstOrDefaultAsync(dt => dt.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(DeviceType), request.Id.ToString());

            _context.DeviceTypes.Remove(deviceType);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}
