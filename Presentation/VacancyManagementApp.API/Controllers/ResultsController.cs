using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.DTOs.Result;
using VacancyManagementApp.Application.Features.Commands.Result.Create;
using VacancyManagementApp.Application.Features.Commands.Result.Update;
using VacancyManagementApp.Application.Features.Queries.GetAllResults;

namespace VacancyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResultsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetAllResultsQueryRequest getAllResultsQueryRequest)
        {
            var response = await _mediator.Send(getAllResultsQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateResultCommandRequest createResultCommandRequest)
        {
            var response = await _mediator.Send(createResultCommandRequest);
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateResult([FromBody] UpdateResultCommandRequest updateResultCommandRequest)
        {
            var response=await _mediator.Send(updateResultCommandRequest);
            return Ok(response);
        }
    }
}
