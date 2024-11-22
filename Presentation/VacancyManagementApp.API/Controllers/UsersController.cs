using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Features.Commands.AppUser.CreateUser;
using VacancyManagementApp.Application.Features.Commands.AppUser.UpdatePassword;
using VacancyManagementApp.Application.Features.Queries.GetAllUser;

namespace VacancyManagementApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllUserQueryRequest getAllUserQueryRequest)
        {
            var response = await _mediator.Send(getAllUserQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        [Route("signIn")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommandRequest createUserCommandRequest)
        {
            CreateUserCommandResponse response = await _mediator.Send(createUserCommandRequest);
            return Ok(response);
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandResponse response = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(response);
        }
    }
}