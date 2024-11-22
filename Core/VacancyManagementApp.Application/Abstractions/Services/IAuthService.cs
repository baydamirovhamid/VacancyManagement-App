using VacancyManagementApp.Application.Abstractions.Services.Authentications;

namespace VacancyManagementApp.Application.Abstractions.Services
{
    public interface IAuthService : IInternalAuthentication
    {
        Task ResetPasswordAsync(string email);
        Task<bool> VerifyResetTokenAsync(string resetToken, string userId);
    }
}
