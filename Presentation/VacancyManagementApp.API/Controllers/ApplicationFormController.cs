using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Features.Commands.ApplicationForm.CreateApplicationForm;
using VacancyManagementApp.Application.Features.Queries.GetAllApplicationForm;
using VacancyManagementApp.Application.Features.Queries.GetAllVacancy;

namespace VacancyManagementApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApplicationFormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplicationFormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateApplicationForm([FromBody] CreateApplicationFormCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllApplicationForm([FromQuery] GetAllApplicationFormQueryRequest getAllApplicationFormQueryRequest)
        {
            var response = await _mediator.Send(getAllApplicationFormQueryRequest);
            return Ok(response);
        }
    }
}