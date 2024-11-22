using VacancyManagementApp.Application.Abstractions.Services.Authentications;

namespace VacancyManagementApp.Application.Abstractions.Services
{
    public interface IAuthService : IInternalAuthentication
    {
        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
    }
}
