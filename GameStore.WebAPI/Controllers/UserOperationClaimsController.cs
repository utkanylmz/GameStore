using Core.Application.Request;
using GameStore.Application.Features.UserOperationClaims.Commands.Create;
using GameStore.Application.Features.UserOperationClaims.Commands.Delete;
using GameStore.Application.Features.UserOperationClaims.Commands.Update;
using GameStore.Application.Features.UserOperationClaims.Dtos.CreateDtos;
using GameStore.Application.Features.UserOperationClaims.Dtos.DeleteDtos;
using GameStore.Application.Features.UserOperationClaims.Dtos.GetByIdDtos;
using GameStore.Application.Features.UserOperationClaims.Dtos.UpdateDtos;
using GameStore.Application.Features.UserOperationClaims.Models;
using GameStore.Application.Features.UserOperationClaims.Queries.GetById;
using GameStore.Application.Features.UserOperationClaims.Queries.GetList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : BaseController
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdUserOperationClaimQuery getByIdUserOperationClaimQuery)
        {
            GetByIdUserOperationClaimDto result = await Mediator.Send(getByIdUserOperationClaimQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserOperationClaimQuery getListUserOperationClaimQuery = new() { PageRequest = pageRequest };
            GetListUserOperationClaimsModel result = await Mediator.Send(getListUserOperationClaimQuery);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserOperationClaimCommand createUserOperationClaimCommand)
        {
            CreatedUserOperationClaimDto result = await Mediator.Send(createUserOperationClaimCommand);
            return Created(uri: "", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateUserOperationClaimCommand updateUserOperationClaimCommand)
        {
            UpdateUserOperationClaimDto result = await Mediator.Send(updateUserOperationClaimCommand);
            return Ok(result);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteUserOperationClaimCommand deleteUserOperationClaimCommand)
        {
            DeletedUserOperationClaimDto result = await Mediator.Send(deleteUserOperationClaimCommand);
            return Ok(result);
        }
    }
}
