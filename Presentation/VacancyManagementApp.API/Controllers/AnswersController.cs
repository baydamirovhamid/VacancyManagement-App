﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Features.Commands.Answer.Create;
using VacancyManagementApp.Application.Features.Commands.Answer.Update;

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

        [HttpPut("update-answer")]
        public async Task<IActionResult> UpdateAnswer([FromBody] UpdateAnswerCommandRequest updateAnswerCommandRequest)
        {
            var response = await _mediator.Send(updateAnswerCommandRequest);
            return Ok(response);
        }
    }
}
