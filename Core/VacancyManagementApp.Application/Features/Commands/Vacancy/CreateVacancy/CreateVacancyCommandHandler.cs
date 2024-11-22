using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.User;
using VacancyManagementApp.Application.DTOs.Vacancy;

namespace VacancyManagementApp.Application.Features.Commands.Vacancy.CreateVacancy
{
    public class CreateVacancyCommandHandler : IRequestHandler<CreateVacancyCommandRequest, CreateVacancyCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IVacancyService _vacancyService;

        public CreateVacancyCommandHandler(IMapper mapper, IVacancyService vacancyService)
        {
            _mapper = mapper;
            _vacancyService = vacancyService;
        }

        public async Task<CreateVacancyCommandResponse> Handle(CreateVacancyCommandRequest request, CancellationToken cancellationToken)
        {
            var createVacancyDto = _mapper.Map<CreateVacancyDto>(request);
            var dto = await _vacancyService.CreateVacancyAsync(createVacancyDto);
            var response =_mapper.Map<CreateVacancyCommandResponse>(dto);
            return response;
        }
    }
}
