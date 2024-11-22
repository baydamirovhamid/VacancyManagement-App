using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.Features.Queries.GetAllQuestions;
using VacancyManagementApp.Application.Features.Queries.GetAllVacancy;

namespace VacancyManagementApp.Application.Features.Queries.GetAllResults
{
    public class GetAllResultsQueryHandler : IRequestHandler<GetAllResultsQueryRequest, GetAllResultsQueryResponse>
    {
        private readonly IResultService _resultService;
        private readonly IMapper _mapper;

        public GetAllResultsQueryHandler(IResultService resultService, IMapper mapper)
        {
            _resultService = resultService;
            _mapper = mapper;
        }

        public async Task<GetAllResultsQueryResponse> Handle(GetAllResultsQueryRequest request, CancellationToken cancellationToken)
        {
            var getAllDto =  _resultService.GetAllResult();
            var responseDto = new GetAllResultsQueryResponse();
            responseDto.GetAllResultDtos = getAllDto;
            return responseDto;
        }
    }
}
