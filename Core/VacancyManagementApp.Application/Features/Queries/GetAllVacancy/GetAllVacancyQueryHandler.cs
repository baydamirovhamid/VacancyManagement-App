using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.Features.Queries.GetAllQuestions;

namespace VacancyManagementApp.Application.Features.Queries.GetAllVacancy
{
    public class GetAllVacancyQueryHandler : IRequestHandler<GetAllVacancyQueryRequest, GetAllVacancyQueryResponse>
    {
        private readonly IVacancyService _vacancyService;

        public GetAllVacancyQueryHandler(IVacancyService vacancyService)
        {
            _vacancyService = vacancyService;
        }

        public async Task<GetAllVacancyQueryResponse> Handle(GetAllVacancyQueryRequest request, CancellationToken cancellationToken)
        {
            var getAllDto = await _vacancyService.GetAllVacancy();
            var responseDto = new GetAllVacancyQueryResponse();
            responseDto.GetAllVacancies = getAllDto;
            return responseDto;
        }
    }
}
