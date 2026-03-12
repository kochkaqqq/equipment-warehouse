using MediatR;

namespace Application.DeviceTypes.Commands.CreateDeviceType
{
    public class CreateDeviceTypesCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; } 
    }
}
