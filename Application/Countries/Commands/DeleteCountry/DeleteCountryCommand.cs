using MediatR;

namespace Application.Countries.Commands.DeleteCountry
{
    public class DeleteCountryCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
