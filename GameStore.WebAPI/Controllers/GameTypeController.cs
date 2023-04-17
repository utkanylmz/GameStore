using Core.Application.Request;
using Core.Persistence.Dynamic;
using GameStore.Application.Features.GameTypes.Commands.CreateGameType;
using GameStore.Application.Features.GameTypes.Commands.DeleteGameType;
using GameStore.Application.Features.GameTypes.Commands.UpdateGameType;
using GameStore.Application.Features.GameTypes.Dtos.CreateDto;
using GameStore.Application.Features.GameTypes.Dtos.DeleteDto;
using GameStore.Application.Features.GameTypes.Dtos.GetDto;
using GameStore.Application.Features.GameTypes.Dtos.UpdatedDto;
using GameStore.Application.Features.GameTypes.Model;
using GameStore.Application.Features.GameTypes.Queries.GetByIdGameType;
using GameStore.Application.Features.GameTypes.Queries.GetListGameType;
using GameStore.Application.Features.GameTypes.Queries.GetListGameTypeByDynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameTypeController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGameTypeQuery query = new() { PageRequest = pageRequest };
            GameTypeGetListModel result=  await Mediator.Send(query);
            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGameTypeCommand createGameTypeCommand)
        {
            CreateGameTypeDto result = await Mediator.Send(createGameTypeCommand);
            return Created("", result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGameTypeQuery getByIdGameTypeQuery) 
        {
            GetByIdDto GetByIdDto = await Mediator.Send(getByIdGameTypeQuery);
            return Ok(GetByIdDto);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateGameTypeCommand updateGameTypeCommand)
        {
            UpdatedGameTypeDto result = await Mediator.Send(updateGameTypeCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteGameTypeCommand deleteGameTypeCommand)
        {
            DeleteGameTypeDto result = await Mediator.Send(deleteGameTypeCommand);
            return Ok(result);
        }

        [HttpPost("GetList/ByDynamic")]
        public async Task<IActionResult> GetListByDynamic([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListGameTypeByDynamicQuery getListGameTypeByDynamic = new GetListGameTypeByDynamicQuery
            {
                PageRequest= pageRequest,Dynamic=dynamic
            };
            GetListGameTypeByDynamicModel getListGameTypeByDynamicModel = await Mediator.Send(getListGameTypeByDynamic);
            return Ok(getListGameTypeByDynamicModel);
        }
    }
}
