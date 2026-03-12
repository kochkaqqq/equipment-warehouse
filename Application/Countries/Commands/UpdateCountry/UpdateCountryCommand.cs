using MediatR;

namespace Application.Countries.Commands.UpdateCountry
{
    public class UpdateCountryCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
    }
}
