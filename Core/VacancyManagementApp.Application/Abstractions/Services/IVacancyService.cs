using VacancyManagementApp.Application.DTOs.Vacancy;

namespace VacancyManagementApp.Application.Abstractions.Services
{
    public interface IVacancyService
    {
        Task<CreateVacancyResponseDto> CreateVacancyAsync(CreateVacancyDto model);
        Task<UpdateVacancyResponseDto> UpdateVacancyAsync(UpdateVacancyDto model);
        Task<RemoveVacancyResponseDto> RemoveVacancyAsync(Guid id);
        Task<List<ListVacancyDto>> GetAllVacancy();
        Task<SingleVacancyDto> GetVacancyByIdAsync(Guid id);
    }
}
