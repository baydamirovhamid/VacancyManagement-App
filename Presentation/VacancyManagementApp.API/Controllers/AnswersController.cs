using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Features.Commands.Answer.Create;
using VacancyManagementApp.Application.Features.Commands.Answer.Update;
using VacancyManagementApp.Application.Features.Queries.GetAllAnswer;
using VacancyManagementApp.Application.Features.Queries.GetAllApplicationForm;

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
        public async Task<IActionResult> CreateAnswer(CreateAnswerCommandRequest createAnswerRequest)
        {
            var response = await _mediator.Send(createAnswerRequest);
            return Ok(response);
        }

        [HttpPut("update-answer")]
        public async Task<IActionResult> UpdateAnswer([FromBody] UpdateAnswerCommandRequest updateAnswerCommandRequest)
        {
            var response = await _mediator.Send(updateAnswerCommandRequest);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnswer([FromQuery] GetAllAnswerQueryRequest getAllAnswerQueryRequest)
        {
            var response = await _mediator.Send(getAllAnswerQueryRequest);
            return Ok(response);
        }
    }
}
