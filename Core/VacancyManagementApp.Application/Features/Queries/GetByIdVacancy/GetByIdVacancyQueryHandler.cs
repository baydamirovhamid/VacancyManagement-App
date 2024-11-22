using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Vacancy;

namespace VacancyManagementApp.Application.Features.Queries.GetByIdVacancy
{
    public class GetByIdVacancyQueryHandler : IRequestHandler<GetByIdVacancyQueryRequest, GetByIdVacancyQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVacancyService _vacancyService;

        public GetByIdVacancyQueryHandler(IMapper mapper, IVacancyService vacancyService)
        {
            _mapper = mapper;
            _vacancyService = vacancyService;
        }

        async Task<GetByIdVacancyQueryResponse> IRequestHandler<GetByIdVacancyQueryRequest, GetByIdVacancyQueryResponse>.Handle(GetByIdVacancyQueryRequest request, CancellationToken cancellationToken)
        {
            var getByIdDto = await _vacancyService.GetVacancyByIdAsync(request.Id);
            var responseDto=_mapper.Map<SingleVacancyDto>(getByIdDto);
            return _mapper.Map<GetByIdVacancyQueryResponse>(responseDto);
        }
    }
}
