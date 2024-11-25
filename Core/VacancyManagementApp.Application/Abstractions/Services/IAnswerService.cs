using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Answer;
using VacancyManagementApp.Application.DTOs.ApplicationForm;
using VacancyManagementApp.Application.DTOs.Vacancy;

namespace VacancyManagementApp.Application.Abstractions.Services
{
    public interface IAnswerService
    {
        Task<CreateAnswerResponseDto> CreateAnswerAsync(CreateAnswerDto dto);
        Task<UpdateAnswerDto> UpdateAnswerAsync(UpdateAnswerDto model);
        Task<List<GetAllAnswerDto>> GetAllAnswer();

    }
}
