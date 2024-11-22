using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Question;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Repositories;

namespace VacancyManagementApp.Persistence.Services
{
    public class QuestionService : IQuestionService
    {
        private readonly IQuestionWriteRepository _questionWriteRepository;
        private readonly IQuestionReadRepository _questionReadRepository;
        private readonly IAnswerReadRepository _answerReadRepository;
        private readonly IWriteRepository<Question> _writeRepository;
        private readonly IMapper _mapper;

        public QuestionService(IQuestionReadRepository questionReadRepository, IMapper mapper, IQuestionWriteRepository questionWriteRepository, IAnswerReadRepository answerReadRepository, IWriteRepository<Question> writeRepository)
        {
            _questionReadRepository = questionReadRepository;
            _mapper = mapper;
            _questionWriteRepository = questionWriteRepository;
            _answerReadRepository = answerReadRepository;
            _writeRepository = writeRepository;
        }

        public async Task<QuestionResponseDto> CreateQuestionAsync(QuestionDto dto)
        {
            var entity =_mapper.Map<Question>(dto);
          var addedResult =  await _questionWriteRepository.AddAsync(entity);
            await _writeRepository.SaveAsync();
            return new()
            {
                Succeeded = addedResult,
                Message="Question created successfully"
            };
        }

        public List<GetAllQuestionDto> GetAllQuestion()
        {
            var entities =  _questionReadRepository.GetAll().ToList();
            return _mapper.Map<List<GetAllQuestionDto>>(entities);
        }

        public async Task<QuestionDto?> GetQuestionByPageAsync(int page, Guid vacancyId)
        {
            // Fetch the questions by vacancyId from the repository
            var question = await _questionReadRepository.GetWhere(q => q.VacancyId == vacancyId)
                .Skip((page - 1) * 1)  // Skip previous questions (page - 1) * 1
                .Take(1)  // Only take 1 question
                .Include("Answers")
                .Select(q => new QuestionDto
                {
                    Description = q.Description,
                    Answers = q.Answers.Select(a => new AnswerDto
                    {
                        AnswerText = a.Name,
                        IsCorrect = a.IsCorrect
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            return question;
        }
    }

}
