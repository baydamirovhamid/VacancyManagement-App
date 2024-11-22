using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.ApplicationForm;
using VacancyManagementApp.Application.DTOs.Vacancy;

namespace VacancyManagementApp.Application.Abstractions.Services
{
    public interface IApplicationFormService
    {
        Task<CreateApplicationFormResponseDto> CreateApplicationFormAsync(CreateApplicationFormDto model);
        Task<List<GetAllApplicationFormDto>> GetAllApplicationForm();


    }


}
