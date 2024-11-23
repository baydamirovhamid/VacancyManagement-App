using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Features.Commands.ApplicationForm.CreateApplicationForm;

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
    }
}