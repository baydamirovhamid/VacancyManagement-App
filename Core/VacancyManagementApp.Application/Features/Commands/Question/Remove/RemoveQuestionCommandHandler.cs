using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;

namespace VacancyManagementApp.Application.Features.Commands.Question.Remove
{
    public class RemoveQuestionCommandHandler : IRequestHandler<RemoveQuestionCommandRequest, RemoveQuestionCommandResponse>
    {
        private readonly IQuestionService _questionService;
        private readonly IMapper _mapper;

        public RemoveQuestionCommandHandler(IQuestionService questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }

        public async Task<RemoveQuestionCommandResponse> Handle(RemoveQuestionCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = await _questionService.RemoveQuestionAsync(request.Id);

            var response = _mapper.Map<RemoveQuestionCommandResponse>(dto);

            return response;
        }
    }
}
