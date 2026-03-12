using Application.Manufacturers.Commands.CreateManufacturer;
using Application.Manufacturers.Commands.DeleteManufacturer;
using Application.Manufacturers.Commands.UpdateManufacturer;
using Application.Manufacturers.Queries.GetAllManufactures;
using Application.Manufacturers.Queries.GetManufacturerList;
using Application.Manufacturers.Queries.GetManufacturersByDeviceTypes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/manufacturers")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManufacturerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateManufacturer([FromBody] CreateManufacturerCommand command)
        {
            var res = await _mediator.Send(command);    
            return Ok(res);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteManufacturer([FromRoute] Guid id)
        {
            var res = await _mediator.Send(new DeleteManufacturerCommand { Id = id });
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateManufacturer([FromBody] UpdateManufacturerCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetManufacturerList()
        {
            var res = await _mediator.Send(new GetAllManufacturersQuery());
            return Ok(res);
        }

        [HttpPost]
        [Route("query")]
        public async Task<IActionResult> GetManufacturerListWithFilter([FromBody] GetManufacturerListQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpPost]
        [Route("get-by-device-types")]
        public async Task<IActionResult> GetManufacturerListByDeviceTypes([FromBody] GetManufacturersByDeviceTypesQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetManufacturerById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
