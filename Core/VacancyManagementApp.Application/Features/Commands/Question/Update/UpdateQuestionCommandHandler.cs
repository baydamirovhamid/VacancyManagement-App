using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Question;

namespace VacancyManagementApp.Application.Features.Commands.Question.Update
{
    public class UpdateQuestionCommandHandler : IRequestHandler<UpdateQuestionCommandRequest, UpdateQuestionCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IQuestionService _questionService;

        public UpdateQuestionCommandHandler(IMapper mapper, IQuestionService questionService)
        {
            _mapper = mapper;
            _questionService = questionService;
        }

        public async Task<UpdateQuestionCommandResponse> Handle(UpdateQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var updateQuestionDto = _mapper.Map<UpdateQuestionDto>(request);

            var dto = await _questionService.UpdateQuestionAsync(updateQuestionDto);

            var response = _mapper.Map<UpdateQuestionCommandResponse>(dto);

            return response;
        }
    }
}
