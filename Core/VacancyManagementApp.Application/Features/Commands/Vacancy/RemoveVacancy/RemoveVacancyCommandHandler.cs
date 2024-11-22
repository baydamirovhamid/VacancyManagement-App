using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.Repositories;

namespace VacancyManagementApp.Application.Features.Commands.Vacancy.RemoveVacancy
{
    public class RemoveVacancyCommandHandler : IRequestHandler<RemoveVacancyCommandRequest, RemoveVacancyCommandResponse>
    {
        private readonly IVacancyService _vacancyService;
        private readonly IMapper _mapper;

        public RemoveVacancyCommandHandler(IVacancyService vacancyService, IMapper mapper)
        {
            _vacancyService = vacancyService;
            _mapper = mapper;
        }

        public async Task<RemoveVacancyCommandResponse> Handle(RemoveVacancyCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = await _vacancyService.RemoveVacancyAsync(request.Id);

            var response = _mapper.Map<RemoveVacancyCommandResponse>(dto);

            return response;
        }
    }
}
