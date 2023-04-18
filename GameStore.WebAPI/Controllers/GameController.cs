using Core.Application.Request;
using Core.Persistence.Dynamic;
using GameStore.Application.Features.Games.Commands.CreateGame;
using GameStore.Application.Features.Games.Commands.DeleteGame;
using GameStore.Application.Features.Games.Commands.UpdateGame;
using GameStore.Application.Features.Games.Dtos.CreateDto;
using GameStore.Application.Features.Games.Dtos.DeleteDto;
using GameStore.Application.Features.Games.Dtos.GetDto;
using GameStore.Application.Features.Games.Dtos.UpdateDto;
using GameStore.Application.Features.Games.Models;
using GameStore.Application.Features.Games.Queries.GetByIdGame;
using GameStore.Application.Features.Games.Queries.GetListGame;
using GameStore.Application.Features.Games.Queries.GetListGameDynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
           GetListGameQuery query = new() { PageRequest=pageRequest };
            GetListGameModel result = await Mediator.Send(query);
            return Ok(result);
        }


        [HttpPost("GetList/Dynamic")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListGameByDynamicQuery query = new() { PageRequest = pageRequest, Dynamic = dynamic };
            GetListGameByDynamicModel result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGameQuery getByIdGameQuery)
        {
            GetByIdGameDto GetByIdDto = await Mediator.Send(getByIdGameQuery);
            return Ok(GetByIdDto);
        }



        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGameCommand createGameCommand)
        {
            CreateGameDto result = await Mediator.Send(createGameCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateGameCommand updateGameCommand)
        {
            UpdateGameDto result = await Mediator.Send(updateGameCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteGameCommand deleteGameCommand)
        {
            DeleteGameDto result = await Mediator.Send(deleteGameCommand);
            return Ok(result);
        }
    }
}
