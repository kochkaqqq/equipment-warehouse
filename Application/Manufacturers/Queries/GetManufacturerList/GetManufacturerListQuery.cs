using Domain.Entities;
using Domain.Filters;
using MediatR;

namespace Application.Manufacturers.Queries.GetManufacturerList
{
    public class GetManufacturerListQuery : IRequest<List<Manufacturer>>
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 15;
        public ManufacturerFilter Filter { get; set; } = new();
    }
}
