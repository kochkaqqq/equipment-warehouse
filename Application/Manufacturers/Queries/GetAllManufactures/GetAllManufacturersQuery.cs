using Domain.Entities;
using MediatR;

namespace Application.Manufacturers.Queries.GetAllManufactures
{
    public class GetAllManufacturersQuery : IRequest<List<Manufacturer>>
    {
    }
}
