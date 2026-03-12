using Domain.Entities;
using MediatR;

namespace Application.Countries.Queries.GetCountryList
{
    public class GetCountryListCommand : IRequest<List<Country>>
    {
    }
}
