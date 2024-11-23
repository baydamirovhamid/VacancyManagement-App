using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Features.Commands.ApplicationForm.CreateApplicationForm;
using VacancyManagementApp.Application.Features.Commands.AppUser.CreateUser;
using VacancyManagementApp.Application.Features.Queries.GetAllApplicationForm;
using VacancyManagementApp.Application.Features.Queries.GetAllUser;

namespace VacancyManagementApp.API.Controllers
{

    //[ApiController]
    //[Route("api/[controller]")]
    //public class ApplicationFormController : ControllerBase
    //{
    //    private readonly IMediator _mediator;

    //    public ApplicationFormController(IMediator mediator)
    //    {
    //        _mediator = mediator;
    //    }

    //    [HttpGet]
    //    public async Task<IActionResult> GetAll([FromQuery] GetAllApplicationFormQueryRequest getAllApplicationFormQueryRequest)
    //    {
    //        var response = await _mediator.Send(getAllApplicationFormQueryRequest);
    //        return Ok(response);
    //    }

    //    [HttpPost]
    //    [Route("create-form")]
    //    public async Task<IActionResult> CreateApplicationForm([FromBody] CreateApplicationFormCommandRequest createApplicationFormCommandRequest)
    //    {
    //        CreateApplicationFormCommandResponse response = await _mediator.Send(createApplicationFormCommandRequest);
    //        return Ok(response);
    //    }
    //}
}