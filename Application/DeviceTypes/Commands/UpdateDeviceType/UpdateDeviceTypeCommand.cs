using MediatR;

namespace Application.DeviceTypes.Commands.UpdateDeviceType
{
    public class UpdateDeviceTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
