using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Question;
using VacancyManagementApp.Domain.Entities;

namespace VacancyManagementApp.Application.Abstractions.Services
{
    public interface IQuestionService
    {
        Task<QuestionDto> GetQuestionByPageAsync(int page, Guid vacancyId);
        Task<QuestionResponseDto> CreateQuestionAsync(QuestionDto dto);
        List<GetAllQuestionDto> GetAllQuestion();
        Task<UpdateQuestionDto> UpdateQuestionAsync(UpdateQuestionDto updateQuestionDto);
        Task<RemoveQuestionResponseDto> RemoveQuestionAsync(Guid id);
    }

}
