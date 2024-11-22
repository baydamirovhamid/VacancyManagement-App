using AutoMapper;
using Microsoft.EntityFrameworkCore;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.Vacancy;
using VacancyManagementApp.Application.Repositories;
using VacancyManagementApp.Domain.Entities;
using VacancyManagementApp.Persistence.Repositories;

namespace VacancyManagementApp.Persistence.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IVacancyWriteRepository _vacancyWriteRepository;
        private readonly IVacancyReadRepository _vacancyReadRepository;
        private readonly IMapper _mapper;

        public VacancyService(IVacancyWriteRepository vacancyWriteRepository, IMapper mapper, IVacancyReadRepository vacancyReadRepository)
        {
            _vacancyWriteRepository = vacancyWriteRepository;
            _mapper = mapper;
            _vacancyReadRepository = vacancyReadRepository;
        }

        public async Task<CreateVacancyResponseDto> CreateVacancyAsync(CreateVacancyDto model)
        {
            var vacancy = _mapper.Map<Vacancy>(model);
            var isEntityAdded = await _vacancyWriteRepository.AddAsync(vacancy);

            await _vacancyWriteRepository.SaveAsync();

            return new CreateVacancyResponseDto
            {
                Succeeded = isEntityAdded,
                Message = isEntityAdded ? "Vacancy created successfully!" : "Vacancy couldn't be created"
            };
            
        }

        public async Task<List<ListVacancyDto>> GetAllVacancy()
        {
            var entities = await _vacancyReadRepository.GetAll().ToListAsync();
            return _mapper.Map<List<ListVacancyDto>>(entities);
        }

        public async Task<SingleVacancyDto> GetVacancyByIdAsync(Guid id)
        {
            var entity =await _vacancyReadRepository.GetByIdAsync(id);
            return _mapper.Map<SingleVacancyDto>(entity);
        }

        public async Task<RemoveVacancyResponseDto> RemoveVacancyAsync(Guid id)
        {
            var vacancy = await _vacancyReadRepository.GetByIdAsync(id);
            var response = new RemoveVacancyResponseDto();

            if (vacancy == null)
            {
                response.Succeeded = false;
                response.Message = "Vacancy not found.";
                return response;
            }

            _vacancyWriteRepository.Remove(vacancy);
            await _vacancyWriteRepository.SaveAsync();

            response.Succeeded = true;
            response.Message = "Vacancy deleted successfully!";
            return response;
        }

        public async Task<UpdateVacancyResponseDto> UpdateVacancyAsync(UpdateVacancyDto model)
        {
            var vacancy = await _vacancyReadRepository.GetByIdAsync(model.Id);

            if (vacancy == null)
            {
                return new UpdateVacancyResponseDto
                {
                    Succeeded = false,
                    Message = "Vacancy not found."
                };
            }

            _mapper.Map(model, vacancy);

            await _vacancyWriteRepository.SaveAsync();

            return new UpdateVacancyResponseDto
            {
                Succeeded = true,
                Message = "Vacancy updated successfully!"
            };
        }
    }
}
