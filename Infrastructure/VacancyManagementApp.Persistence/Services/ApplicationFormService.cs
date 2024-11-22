using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.ApplicationForm;
using VacancyManagementApp.Application.DTOs.Result;
using VacancyManagementApp.Application.DTOs.User;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Repositories;

namespace VacancyManagementApp.Persistence.Services
{
    public class ApplicationFormService : IApplicationFormService
    {
        private readonly IApplicationFormWriteRepository _applicationFormWriteRepository;
        private readonly IApplicationFormReadRepository _applicationFormReadRepository;
        private readonly IMapper _mapper;

        public ApplicationFormService(IApplicationFormWriteRepository applicationFormWriteRepository, IMapper mapper, IApplicationFormReadRepository applicationFormReadRepository)
        {
            _applicationFormWriteRepository = applicationFormWriteRepository;
            _mapper = mapper;
            _applicationFormReadRepository = applicationFormReadRepository;
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

        public async Task<List<GetAllApplicationFormDto>> GetAllApplicationForm()
        {
            var entities = await _applicationFormReadRepository.GetAll().ToListAsync();
            return _mapper.Map<List<GetAllApplicationFormDto>>(entities);
        }


    }

}
