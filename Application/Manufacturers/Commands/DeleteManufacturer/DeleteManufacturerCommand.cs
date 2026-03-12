using MediatR;

namespace Application.Manufacturers.Commands.DeleteManufacturer
{
    public class DeleteManufacturerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
