using MediatR;
using Microsoft.AspNetCore.Mvc;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.Features.Commands.Question.Create;
using VacancyManagementApp.Application.Features.Commands.Question.Remove;
using VacancyManagementApp.Application.Features.Commands.Question.Update;
using VacancyManagementApp.Application.Features.Queries.GetAllQuestions;

[ApiController]
[Route("api/[controller]")]
public class QuestionController : ControllerBase
{
    private readonly IQuestionService _questionService;
    private readonly IMediator _mediator;
    public QuestionController(IQuestionService questionService, IMediator mediator)
    {
        _questionService = questionService;
        this._mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetQuestionByPage([FromQuery] Guid vacancyId, [FromQuery] int page = 1)
    {
        if (vacancyId == Guid.Empty)
        {
            return BadRequest("VacancyId is required.");
        }

        var result = await _questionService.GetQuestionByPageAsync(page, vacancyId);

        if (result == null)
        {
            return NotFound("Question not found.");
        }

        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> CreateQuestion([FromBody]CreateQuestionCommandRequest createQuestionCommandRequest)
    {
        var response = await _mediator.Send(createQuestionCommandRequest);
        return Ok(response);
    }


    [HttpGet("get-all-questions")]
    public async Task<IActionResult> GetAllQuestion([FromQuery]GetAllQuestionQueryRequest getAllQuestionQueryRequest)
    {
        GetAllQuestionQueryResponse response = await _mediator.Send(getAllQuestionQueryRequest);
        return Ok(response);
    }

    [HttpPut("update-question")]
    public async Task<IActionResult> UpdateQuestion([FromBody] UpdateQuestionCommandRequest updateQuestionCommandRequest)
    {
        var response = await _mediator.Send(updateQuestionCommandRequest);
        return Ok(response);
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> RemoveQuestion([FromRoute] RemoveQuestionCommandRequest removeQuestionCommandRequest)
    {
        RemoveQuestionCommandResponse response = await _mediator.Send(removeQuestionCommandRequest);
        return Ok(response);

    }

}
