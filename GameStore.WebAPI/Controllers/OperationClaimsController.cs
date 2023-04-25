using Core.Application.Request;
using GameStore.Application.Features.OperationClaims.Commands.Create;
using GameStore.Application.Features.OperationClaims.Commands.Delete;
using GameStore.Application.Features.OperationClaims.Commands.Update;
using GameStore.Application.Features.OperationClaims.Dtos.CreateDto;
using GameStore.Application.Features.OperationClaims.Dtos.DeleteDto;
using GameStore.Application.Features.OperationClaims.Dtos.GetByIdDto;
using GameStore.Application.Features.OperationClaims.Dtos.UpdateDto;
using GameStore.Application.Features.OperationClaims.Models.GetList;
using GameStore.Application.Features.OperationClaims.Queries.GetById;
using GameStore.Application.Features.OperationClaims.Queries.GetList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationClaimsController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdOperationClaimQuery getByIdOperationClaimQuery)
        {
            GetByIdOperationClaimDto result = await Mediator.Send(getByIdOperationClaimQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListOperationClaimQuery getListOperationClaimQuery = new() { PageRequest = pageRequest };
           GetListOperationClaimModel result = await Mediator.Send(getListOperationClaimQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateOperationClaimCommand createOperationClaimCommand)
        {
            CreatedOperationClaimDto result = await Mediator.Send(createOperationClaimCommand);
            return Created(uri: "", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateOperationClaimCommand updateOperationClaimCommand)
        {
            UpdatedOperationClaimDto result = await Mediator.Send(updateOperationClaimCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteOperationClaimsCommand deleteOperationClaimCommand)
        {
            DeletedOperationClaimDto result = await Mediator.Send(deleteOperationClaimCommand);
            return Ok(result);
        }
    }
}
