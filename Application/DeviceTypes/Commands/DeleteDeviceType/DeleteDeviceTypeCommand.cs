using MediatR;

namespace Application.DeviceTypes.Commands.DeleteDeviceType
{
    public class DeleteDeviceTypeCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
