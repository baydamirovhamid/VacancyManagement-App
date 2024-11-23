using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<CreateApplicationFormDto> _createApplicationFormValidator;
        private readonly IMapper _mapper;

        public ApplicationFormService(IApplicationFormWriteRepository applicationFormWriteRepository, IMapper mapper, IApplicationFormReadRepository applicationFormReadRepository, IValidator<CreateApplicationFormDto> createApplicationFormValidator)
        {
            _applicationFormWriteRepository = applicationFormWriteRepository;
            _mapper = mapper;
            _applicationFormReadRepository = applicationFormReadRepository;
            _createApplicationFormValidator = createApplicationFormValidator;
        }

        public async Task<CreateApplicationFormResponseDto> CreateApplicationFormAsync(CreateApplicationFormDto model)
        {
            var validationResult = await _createApplicationFormValidator.ValidateAsync(model);

            if (!validationResult.IsValid)
            {
                return new CreateApplicationFormResponseDto
                {
                    Success = false,
                    Message = validationResult.Errors[0].ErrorMessage,
                };
            }

            var applicationForm = _mapper.Map<ApplicationForm>(model);

            await _applicationFormWriteRepository.AddAsync(applicationForm);
            await _applicationFormWriteRepository.SaveAsync();

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


