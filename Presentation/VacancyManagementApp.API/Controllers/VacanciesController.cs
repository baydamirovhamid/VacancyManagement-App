using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Features.Commands.Vacancy.CreateVacancy;
using VacancyManagementApp.Application.Features.Commands.Vacancy.RemoveVacancy;
using VacancyManagementApp.Application.Features.Commands.Vacancy.UpdateVacancy;
using VacancyManagementApp.Application.Features.Queries.GetAllQuestions;
using VacancyManagementApp.Application.Features.Queries.GetAllVacancy;
using VacancyManagementApp.Application.Features.Queries.GetByIdVacancy;

namespace VacancyManagementApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VacanciesController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]GetAllVacancyQueryRequest getAllVacancyQuery)
        {
            var response = await _mediator.Send(getAllVacancyQuery);
            return Ok(response);
        }
        [HttpGet("id")]
        public async Task<IActionResult> Get([FromQuery]GetByIdVacancyQueryRequest getByIdVacancyRequest)
        {
            var response = await _mediator.Send(getByIdVacancyRequest);
            return Ok(response);
        }
        [HttpPost("create-vacancy")]
        public async Task<IActionResult> CreateVacancy([FromBody]CreateVacancyCommandRequest createVacancyCommandRequest)
        {
            var response = await _mediator.Send(createVacancyCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> RemoveVacancy([FromRoute] RemoveVacancyCommandRequest removeVacancyCommandRequest)
        {
            RemoveVacancyCommandResponse response = await _mediator.Send(removeVacancyCommandRequest);
            return Ok(response);

        }

        [HttpPut("update-vacancy")]
        public async Task<IActionResult> UpdateVacancy([FromBody] UpdateVacancyCommandRequest updateVacancyCommandRequest)
        {
            var response = await _mediator.Send(updateVacancyCommandRequest);
            return Ok(response);
        }
    }
}
