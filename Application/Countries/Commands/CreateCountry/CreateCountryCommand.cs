using MediatR;

namespace Application.Countries.Commands.CreateCountry
{
    public class CreateCountryCommand : IRequest<Guid>
    {
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
    }
}
