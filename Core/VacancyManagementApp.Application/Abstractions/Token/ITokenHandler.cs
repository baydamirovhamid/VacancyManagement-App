using VacancyManagementApp.Domain.Entities.Identity;

namespace VacancyManagementApp.Application.Abstractions.Token
{
    public interface ITokenHandler
    {
        DTOs.Auth.Token CreateAccessToken(int second, AppUser appUser);
        string CreateRefreshToken();
    }
}
