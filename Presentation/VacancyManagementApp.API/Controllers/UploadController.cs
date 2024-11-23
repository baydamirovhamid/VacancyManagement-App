using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Features.Commands.UploadFile;
using VacancyManagementApp.Application.Features.Queries.GetAllFile;

namespace VacancyManagementApp.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class FileUploadController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FileUploadController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile([FromForm]UploadFileCommandRequest uploadFileCommandRequest)
        {
            var response = await _mediator.Send(uploadFileCommandRequest);

            if (response.Success)
            {
                return Ok(new { response.Message, response.FileName });
            }
            return BadRequest(response);
        }


        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByOwner([FromRoute]GetFileQueryRequest getFileQueryRequest)
        {
            var response=await _mediator.Send(getFileQueryRequest);
            return  Ok(response);
        }
    }

}
