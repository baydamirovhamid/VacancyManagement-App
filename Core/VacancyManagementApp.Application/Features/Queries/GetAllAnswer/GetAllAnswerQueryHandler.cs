using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Answer;
using VacancyManagementApp.Application.DTOs.ApplicationForm;
using VacancyManagementApp.Application.Features.Queries.GetAllApplicationForm;

namespace VacancyManagementApp.Application.Features.Queries.GetAllAnswer
{
    public class GetAllAnswerQueryHandler : IRequestHandler<GetAllAnswerQueryRequest, GetAllAnswerQueryResponse>
    {
        private readonly IAnswerService _answerService;
        private readonly IMapper _mapper;

        public GetAllAnswerQueryHandler(IAnswerService answerService, IMapper mapper)
        {
            _answerService = answerService;
            _mapper = mapper;
        }

        public async Task<GetAllAnswerQueryResponse> Handle(GetAllAnswerQueryRequest request, CancellationToken cancellationToken)
        {
            var entities = await _answerService.GetAllAnswer();
            var response = new GetAllAnswerQueryResponse();
            var getAllAnswerDto = _mapper.Map<List<GetAllAnswerDto>>(entities);
            response.GetAllAnswer = getAllAnswerDto;
            return response;
        }
    }
}
