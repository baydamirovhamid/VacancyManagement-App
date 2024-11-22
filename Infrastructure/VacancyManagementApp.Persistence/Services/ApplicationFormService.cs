using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.ApplicationForm;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;

namespace VacancyManagementApp.Persistence.Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly IApplicationFormWriteRepository _applicationFormWriteRepository;
        private readonly IMapper _mapper;

        public ApplicationFormService(IApplicationFormWriteRepository applicationFormWriteRepository, IMapper mapper)
        {
            _applicationFormWriteRepository = applicationFormWriteRepository;
            _mapper = mapper;
        }

        public async Task<CreateApplicationFormResponseDto> CreateApplicationFormAsync(CreateApplicationFormDto model)
        {
            // Map the request to the ApplicationForm entity using AutoMapper
            var applicationForm = _mapper.Map<ApplicationForm>(model);

            // Add the application form to the database
            await _applicationFormWriteRepository.AddAsync(applicationForm);
            await _applicationFormWriteRepository.SaveAsync();

            // Return the response DTO
            return new CreateApplicationFormResponseDto
            {
                Success = true,
                Message = "Application form successfully created."
            };
        }
    }

}
