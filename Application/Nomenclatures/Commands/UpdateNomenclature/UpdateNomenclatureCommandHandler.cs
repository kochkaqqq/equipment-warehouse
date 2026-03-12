using Application.Shared.Exceptions;
using Application.Shared.Interfaces;
using Domain.Entities;
using Domain.ValueObjects.Nomenclature;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Nomenclatures.Commands.UpdateNomenclature
{
    public class UpdateNomenclatureCommandHandler : IRequestHandler<UpdateNomenclatureCommand, Nomenclature>
    {
        private readonly IDbContext _context;

        public UpdateNomenclatureCommandHandler(IDbContext context)
        {
            _context = context;
        }

        public async Task<Nomenclature> Handle(UpdateNomenclatureCommand request, CancellationToken cancellationToken)
        {
            var nomenclature = await _context.Nomenclatures.FirstOrDefaultAsync(n => n.Id == request.Id, cancellationToken)
                ?? throw new EntityNotFoundException(nameof(Nomenclature), request.Id.ToString());

            if (request.DeviceTypeId != null)
            {
                var deviceType = await _context.DeviceTypes.FirstOrDefaultAsync(dt => dt.Id == request.DeviceTypeId, cancellationToken)
                    ?? throw new EntityNotFoundException(nameof(DeviceType), request.DeviceTypeId.ToString());

                nomenclature.DeviceType = deviceType;
            }

            if (request.ManufacturerId != null)
            {
                var manufacturer = await _context.Manufacturers.FirstOrDefaultAsync(m => m.Id == request.ManufacturerId, cancellationToken)
                    ?? throw new EntityNotFoundException(nameof(Manufacturer), request.ManufacturerId.ToString());

                nomenclature.Manufacturer = manufacturer;
            }

            if (request.CountryId != null)
            {
                var country = await _context.Countries.FirstOrDefaultAsync(c => c.Id == request.CountryId, cancellationToken)
                    ?? throw new EntityNotFoundException(nameof(Country), request.CountryId.ToString());

                nomenclature.Country = country;
            }

            if (!string.IsNullOrEmpty(request.ModelName))
            {
                nomenclature.ModelName = new ModelName(request.ModelName);
            }

            if (!string.IsNullOrEmpty(request.DeviceImageUrl))
            {
                DeviceImage deviceImage;

                deviceImage = new DeviceImage(request.DeviceImageUrl, request.DeviceImageCaption ?? nomenclature.DeviceImage.Caption);

                nomenclature.DeviceImage = deviceImage;
            }
            else if (request.DeviceImageCaption != null)
            {
                var deviceImage = new DeviceImage(nomenclature.DeviceImage.Url, request.DeviceImageCaption);

                nomenclature.DeviceImage = deviceImage;
            }

            if (request.Price != null)
            {
                nomenclature.Price = new Price(request.Price.Value, request.Currency ?? nomenclature.Price.Currency);
            }
            else if (!string.IsNullOrEmpty(request.Currency))
            {
                nomenclature.Price = new Price(nomenclature.Price.Value, request.Currency);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return nomenclature;
        }
    }
}
