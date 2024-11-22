using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Features.Commands.Answer.Create;

namespace VacancyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnswersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create-answer")]
        public async Task<IActionResult> CreateAsnwer(CreateAnswerCommandRequest createAnswerRequest)
        {
            var response = await _mediator.Send(createAnswerRequest);
            return Ok(response);
        }
    }
}
