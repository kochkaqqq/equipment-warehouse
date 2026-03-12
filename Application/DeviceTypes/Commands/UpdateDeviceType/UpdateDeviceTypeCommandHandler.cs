using Application.Shared.Exceptions;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.ValueObjects.Handbook;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.DeviceTypes.Commands.UpdateDeviceType
{
    public class UpdateDeviceTypeCommandHandler : IRequestHandler<UpdateDeviceTypeCommand, Unit>
    {
        private readonly IDbContext _context;

        public UpdateDeviceTypeCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateDeviceTypeCommand request, CancellationToken cancellationToken)
        {
            var deviceType = await _context.DeviceTypes.FirstOrDefaultAsync(dt => dt.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(DeviceType), request.Id.ToString());

            if (!string.IsNullOrEmpty(request.Name))
            {
                deviceType.Name = new Name(request.Name);
            }

            if (request.Description != null)
            {
                deviceType.Description = new Description(request.Description);
            }

            deviceType.UpdatedAt = DateTime.UtcNow;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
