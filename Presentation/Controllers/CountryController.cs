using Application.Countries.Commands.CreateCountry;
using Application.Countries.Commands.DeleteCountry;
using Application.Countries.Commands.UpdateCountry;
using Application.Countries.Queries.GetCountryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/countries")]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCountry([FromRoute] Guid id)
        {
            var res = await _mediator.Send(new DeleteCountryCommand { Id = id });
            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryCommand command)
        {
            var res = await _mediator.Send(command);
            return Ok(res);
        }

        [HttpGet]
        public async Task<IActionResult> GetCountryList()
        {
            var res = await _mediator.Send(new GetCountryListCommand());
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCountryById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
