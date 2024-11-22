using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Answer;
using VacancyManagementApp.Application.DTOs.Vacancy;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;

namespace VacancyManagementApp.Persistence.Services
{
    public class AnswerService : IAnswerService
    {
        private readonly IAnswerWriteRepository _answerWriteRepository;
        private readonly IMapper _mapper;

        public AnswerService(IAnswerWriteRepository answerWriteRepository, IMapper mapper)
        {
            _answerWriteRepository = answerWriteRepository;
            _mapper = mapper;
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

        public Task<List<ListVacancyDto>> GetAllVacancy()
        {
            throw new NotImplementedException();
        }

        public Task<SingleVacancyDto> GetVacancyByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<RemoveVacancyResponseDto> RemoveVacancyAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<UpdateVacancyResponseDto> UpdateVacancyAsync(UpdateVacancyDto model)
        {
            throw new NotImplementedException();
        }
    }
}
