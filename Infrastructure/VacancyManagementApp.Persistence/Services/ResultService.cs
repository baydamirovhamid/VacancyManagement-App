using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Question;
using VacancyManagementApp.Application.DTOs.Result;
using VacancyManagementApp.Application.DTOs.Vacancy;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Repositories;

namespace VacancyManagementApp.Persistence.Services
{
    public class ResultService : IResultService
    {
        private readonly IReadRepository<Result> _readRepository;
        private readonly IWriteRepository<Result> _writeRepository;
        private readonly IMapper _mapper;
        public ResultService(IReadRepository<Result> readRepository, IWriteRepository<Result> writeRepository, IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task<ResultResponseDto> CreateResultAsync(ResultCreateDto dto)
        {
            var entity=_mapper.Map<Result>(dto);
           var added = await _writeRepository.AddAsync(entity);
           await _writeRepository.SaveAsync();
            return new()
            {
                Succeeded = added,
                Message = added?"Result created successfully":"Result cannot be created",
                
            };
        }

        public  List<GetAllResultDto> GetAllResult()
        {
           var entities = _readRepository.GetAll().ToList();
            return _mapper.Map<List<GetAllResultDto>>(entities);
        }


        public async Task<ResultResponseDto> UpdateResultAsync(UpdateResultDto model)
        {
            var vacancy = await _readRepository.GetByIdAsync(model.Id);

            if (vacancy == null)
            {
                return new ResultResponseDto
                {
                    Succeeded = false,
                    Message = "Result not found."
                };
            }

            _mapper.Map(model, vacancy);

            await _writeRepository.SaveAsync();

            return new ResultResponseDto
            {
                Succeeded = true,
                Message = "Result updated successfully!"
            };
        }
    }
}
