using MediatR;

namespace Application.Manufacturers.Commands.UpdateManufacturer
{
    public class UpdateManufacturerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; } 
        public string? Description { get; set; }
    }
}
