using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Answer;
using VacancyManagementApp.Application.DTOs.ApplicationForm;
using VacancyManagementApp.Application.DTOs.Vacancy;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Repositories;

namespace VacancyManagementApp.Persistence.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerWriteRepository _answerWriteRepository;
        private readonly IAnswerReadRepository _answerReadRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerWriteRepository answerWriteRepository, IMapper mapper, IAnswerReadRepository answerReadRepository)
        {
            _answerWriteRepository = answerWriteRepository;
            _mapper = mapper;
            _answerReadRepository = answerReadRepository;
        }

        public async Task<CreateAnswerResponseDto> CreateAnswerAsync(CreateAnswerDto dto)
        {
            var entity = _mapper.Map<Answer>(dto);
            await _answerWriteRepository.AddAsync(entity);
            await _answerWriteRepository.SaveAsync();
            return new()
            {
                Succeeded = true,
                Message = "Answer created successfully"
            };
        }

        public async Task<UpdateAnswerDto> UpdateAnswerAsync(UpdateAnswerDto model)
        {
            var answer = await _answerReadRepository.GetByIdAsync(model.Id);

            if (answer == null)
            {
                throw new Exception("Question not found.");
            }

            answer.Name = model.Name;
            answer.QuestionId = model.QuestionId;

            _answerWriteRepository.Update(answer);
            await _answerWriteRepository.SaveAsync();

            return model;
        }
        public async Task<List<GetAllAnswerDto>> GetAllAnswer()
        {
            var entities = await _answerReadRepository.GetAll().ToListAsync();
            return _mapper.Map<List<GetAllAnswerDto>>(entities);
        }
    }
}
