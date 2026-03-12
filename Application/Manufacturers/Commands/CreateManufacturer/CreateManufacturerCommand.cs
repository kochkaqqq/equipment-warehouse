using MediatR;

namespace Application.Manufacturers.Commands.CreateManufacturer
{
    public class CreateManufacturerCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
    }
}
