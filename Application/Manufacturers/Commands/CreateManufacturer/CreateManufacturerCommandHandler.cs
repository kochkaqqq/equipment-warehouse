using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.ValueObjects.Handbook;
using MediatR;

namespace Application.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommandHandler : IRequestHandler<CreateManufacturerCommand, Guid>
    {
        private readonly IDbContext _context;

        public CreateManufacturerCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(CreateManufacturerCommand request, CancellationToken cancellationToken)
        {
            var manufacturer = new Manufacturer()
            {
                Name = new Name(request.Name),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
            };

            if (!string.IsNullOrEmpty(request.Description))
            {
                manufacturer.Description = new Description(request.Description);
            }
            else
            {
                manufacturer.Description = null;
            }

            await _context.Manufacturers.AddAsync(manufacturer, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return manufacturer.Id;
        }
    }
}
