using Application.Shared.Interfaces;
using MediatR;
using Domain.ValueObjects.Handbook;

namespace Application.DeviceTypes.Commands.CreateDeviceType
{
    public class CreateDeviceTypesCommandHandler : IRequestHandler<CreateDeviceTypesCommand, Guid>
    {
        private readonly IDbContext _dbContext;

        public CreateDeviceTypesCommandHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateDeviceTypesCommand request, CancellationToken cancellationToken)
        {
            var deviceType = new Domain.Entities.DeviceType
            {
                Id = Guid.NewGuid(),
                Name = new Name(request.Name),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            if (request.Description != null)
            {
                deviceType.Description = new Description(request.Description);
            }
            else
            {
                deviceType.Description = null;
            }

            await _dbContext.DeviceTypes.AddAsync(deviceType, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return deviceType.Id;
        }
    }
}
