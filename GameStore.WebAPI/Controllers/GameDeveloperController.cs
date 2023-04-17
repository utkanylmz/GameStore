using Core.Application.Request;
using Core.Persistence.Dynamic;
using GameStore.Application.Features.GameDevelopers.Commands.CreateGameDeveloper;
using GameStore.Application.Features.GameDevelopers.Commands.DeleteGameDeveloper;
using GameStore.Application.Features.GameDevelopers.Commands.UpdateGameDeveloper;
using GameStore.Application.Features.GameDevelopers.Dtos.CreateDtos;
using GameStore.Application.Features.GameDevelopers.Dtos.DeleteDtos;
using GameStore.Application.Features.GameDevelopers.Dtos.GetDtos;
using GameStore.Application.Features.GameDevelopers.Dtos.UpdateDtos;
using GameStore.Application.Features.GameDevelopers.Models;
using GameStore.Application.Features.GameDevelopers.Queries.GetByIdGameDeveloper;
using GameStore.Application.Features.GameDevelopers.Queries.GetListGameDeveloper;
using GameStore.Application.Features.GameDevelopers.Queries.GetListGameDeveloperByDynamic;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameDeveloperController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListGameDeveloperQuery query = new() { PageRequest = pageRequest };
            GetListGameDeveloperModel result = await Mediator.Send(query);
            return Ok(result);
        }


        [HttpPost("GetList/Dynamic")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest, [FromBody] Dynamic dynamic)
        {
            GetListGameDeveloperByDynamicQuery query = new() { PageRequest = pageRequest ,Dynamic=dynamic};
            GetListGameDeveloperByDynamicModel  result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdGameDeveloperQuery getByIdGameDeveloperQuery)
        {
            GetByIdGameDeveloperDto GetByIdDto = await Mediator.Send(getByIdGameDeveloperQuery);
            return Ok(GetByIdDto);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateGameDeveloperCommand createGameDeveloperCommand) 
        {
            CreateGameDeveloperDto result = await Mediator.Send(createGameDeveloperCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery] UpdateGameDeveloperCommand updateGameDeveloperCommand)
        {
            UpdateGameDeveloperDto result = await Mediator.Send(updateGameDeveloperCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteGameDeveloperCommand deleteGameDeveloperCommand)
        {
            DeleteGameDeveloperDto result = await Mediator.Send(deleteGameDeveloperCommand);
            return Ok(result);
        }
    }
}
