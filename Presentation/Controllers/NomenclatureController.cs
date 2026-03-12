using Application.Nomenclatures.Commands.CreateNomenclature;
using Application.Nomenclatures.Commands.DeleteNomenclature;
using Application.Nomenclatures.Commands.UpdateNomenclature;
using Application.Nomenclatures.Queries.GetNomenclaturesList;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Presentation.Habs;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/nomenclatures")]
    public class NomenclatureController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IHubContext<NomenclatureUpdateHub> _hubContext;

        public NomenclatureController(IMediator mediator, IHubContext<NomenclatureUpdateHub> hubContext)
        {
            _mediator = mediator;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateNomenclature([FromBody] CreateNomenclatureCommand command)
        {
            var res = await _mediator.Send(command);

            await _hubContext.Clients.All.SendAsync("CollectionChanged", "create", res.Id, res);

            return Ok(res.Id);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteNomenclature([FromRoute] Guid id)
        {
            var res = await _mediator.Send(new DeleteNomenclatureCommand() { Id = id});

            await _hubContext.Clients.All.SendAsync("CollectionChanged", "delete", id, null);

            return Ok(res);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateNomenclature([FromBody] UpdateNomenclatureCommand command)
        {
            var res = await _mediator.Send(command);

            await _hubContext.Clients.All.SendAsync("CollectionChanged", "update", res.Id, res);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetNomenclatureList()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [Route("query")]
        public async Task<IActionResult> GetNomenclatureListByFilter([FromBody] GetNomenclatureListQuery query)
        {
            var res = await _mediator.Send(query);
            return Ok(res);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetNomenclatureById([FromRoute] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
