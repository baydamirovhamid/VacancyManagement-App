using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Question;
using VacancyManagementApp.Application.DTOs.Result;

namespace VacancyManagementApp.Application.Abstractions.Services
{
    public interface IResultService
    {
        Task<ResultResponseDto> CreateResultAsync(ResultCreateDto dto);
        List<GetAllResultDto> GetAllResult();
        Task<ResultResponseDto> UpdateResultAsync(UpdateResultDto model);
    }
}
