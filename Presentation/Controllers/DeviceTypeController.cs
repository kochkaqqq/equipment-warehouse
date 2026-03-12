using Application.DeviceTypes.Commands.CreateDeviceType;
using Application.DeviceTypes.Commands.DeleteDeviceType;
using Application.DeviceTypes.Commands.UpdateDeviceType;
using Application.DeviceTypes.Queries.GetAllDeviceTypes;
using Application.DeviceTypes.Queries.GetDeviceTypesByManufacturers;
using Application.DeviceTypes.Queries.GetDeviceTypesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/device-types")]
    public class DeviceTypeController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDeviceType([FromBody] CreateDeviceTypesCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteDeviceType([FromRoute] Guid id)
        {
            var res = await _mediator.Send(new DeleteDeviceTypeCommand { Id = id });
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDeviceType([FromBody] UpdateDeviceTypeCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetDeviceTypeList()
        {
            var res = await _mediator.Send(new GetAllDeviceTypesQuery());
            return Ok(res);
        }

        [HttpPost]
        [Route("query")]
        public async Task<IActionResult> GetDeviceTypeListByFilter([FromBody] GetDeviceTypesListQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpPost]
        [Route("get-by-manufacturers")]
        public async Task<IActionResult> GetDeviceTypeListByManufacturers([FromBody] GetDeviceTypesByManufacturersQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetDeviceTypeById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
