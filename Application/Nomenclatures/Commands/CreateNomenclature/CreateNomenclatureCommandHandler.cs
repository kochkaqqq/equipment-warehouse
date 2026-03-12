using Application.Shared.Exceptions;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.ValueObjects.Nomenclature;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Nomenclatures.Commands.CreateNomenclature
{
    public class CreateNomenclatureCommandHandler : IRequestHandler<CreateNomenclatureCommand, Nomenclature>
    {
        private readonly IDbContext _context;

        public CreateNomenclatureCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Nomenclature> Handle(CreateNomenclatureCommand request, CancellationToken cancellationToken)
        {
            var deviceType = await _context.DeviceTypes.FirstOrDefaultAsync(dt => dt.Id == request.DeviceTypeId, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(DeviceType), request.DeviceTypeId.ToString());

            var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == request.ManufacturerId, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Manufacturer), request.ManufacturerId.ToString());

            var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == request.CountryId, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Country), request.CountryId.ToString());

            if (request.DeviceImageCaption == null)
                request.DeviceImageCaption = string.Empty;
            var deviceImage = new DeviceImage(request.DeviceImageUrl, request.DeviceImageCaption);

            if (request.Currency == null)
                request.Currency = "RUB";
            var price = new Price(request.Price, request.Currency);

            var deviceName = new ModelName(request.ModelName);

            var nomenclature = new Nomenclature
            {
                Id = Guid.NewGuid(),
                DeviceImage = deviceImage,
                DeviceType = deviceType,
                Manufacturer = manufacturer,
                ModelName = deviceName,
                Country = country,
                Price = price,
                CreateAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            await _context.Nomenclatures.AddAsync(nomenclature, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return nomenclature;
        }
    }
}
