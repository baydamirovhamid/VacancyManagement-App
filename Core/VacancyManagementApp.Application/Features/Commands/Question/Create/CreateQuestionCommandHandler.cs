using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Question;

namespace VacancyManagementApp.Application.Features.Commands.Question.Create
{
    public class CreateQuestionCommandHandler : IRequestHandler<CreateQuestionCommandRequest, CreateQuestionCommandResponse>
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public CreateQuestionCommandHandler(IMapper mapper, IQuestionService questionService)
        {
            _mapper = mapper;
            this._questionService = questionService;
        }

        public async Task<CreateQuestionCommandResponse> Handle(CreateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var createQuestionDto = _mapper.Map<QuestionDto>(request);
            var responseDto = await _questionService.CreateQuestionAsync(createQuestionDto);
            return _mapper.Map<CreateQuestionCommandResponse>(responseDto);
        }
    }
}
