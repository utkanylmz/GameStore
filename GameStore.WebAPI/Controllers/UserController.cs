using Core.Application;
using Core.Application.Request;
using GameStore.Application.Features.Users.Commands.CreateUser;
using GameStore.Application.Features.Users.Commands.DeleteUser;
using GameStore.Application.Features.Users.Commands.UpdateUser;
using GameStore.Application.Features.Users.Dtos.CreateUser;
using GameStore.Application.Features.Users.Dtos.DeleteUser;
using GameStore.Application.Features.Users.Dtos.GetByIdUser;
using GameStore.Application.Features.Users.Dtos.UpdatedUser;
using GameStore.Application.Features.Users.Models.UserListUser;
using GameStore.Application.Features.Users.Queries.GetByIdUser;
using GameStore.Application.Features.Users.Queries.GetListUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GameStore.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;
      
        
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserCommand createUserCommand)
        {
             CreatedUserDto result = await Mediator.Send(createUserCommand);
            
            return Created("", result);
        }

      
        
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListUserQuery getListUserQuery = new() { PageRequest = pageRequest };
            UserListModel result=  await Mediator.Send(getListUserQuery);
            return Ok(result);

        }
      
        
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute]GetByIdUserQuery getByIdUserQuery)
        {
            UserGetByIdDto userGetByIdDto = await Mediator.Send(getByIdUserQuery);
            return Ok(userGetByIdDto);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromQuery] DeleteUserCommand deleteUserCommand)
        {
            DeletedUserDto result= await Mediator.Send(deleteUserCommand); 
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromQuery]UpdateUserCommand updateUserCommand)
        {
          UpdatedUserDto result  = await Mediator.Send(updateUserCommand);
            return Ok(result);
        }

        [HttpPut("status")]
        public async Task<IActionResult> UpdateStatus([FromQuery]UpdateUserStatusCommand updateStatusCommand)
        {
            UpdatedUserStatusDto result = await Mediator.Send(updateStatusCommand);
            return Ok(result);
        }
    }
}
