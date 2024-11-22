using AutoMapper;
using Microsoft.AspNetCore.Identity;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.DTOs.User;
using VacancyManagementApp.Application.Exceptions;
using VacancyManagementApp.Domain.Entities.Identity;
using U = VacancyManagementApp.Domain.Entities.Identity;
using VacancyManagementApp.Application.Helpers;
using Microsoft.EntityFrameworkCore;
using VacancyManagementApp.Application.DTOs.Result;


namespace VacancyManagementApp.Persistence.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<U.AppUser> _userManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<U.AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }
        public async Task<CreateUserResponseDto> CreateAsync(CreateUserDto model)
        {
            var identityUser = _mapper.Map<U.AppUser>(model);

            IdentityResult result = await _userManager.CreateAsync(identityUser, model.Password);

            CreateUserResponseDto response = new() { Succeeded = result.Succeeded };

            if (result.Succeeded)
                response.Message = "User created successfully!";
            else
                foreach (var error in result.Errors)
                    response.Message += $"{error.Code} - {error.Description}\n";

            return response;
        }

        public async Task UpdateRefreshTokenAsync(string refreshToken, AppUser user, DateTime accessTokenDate, int addOnAccessTokenDate)
        {
            if (user != null)
            {
                user.RefreshToken = refreshToken;
                user.RefreshTokenEndDate = accessTokenDate.AddSeconds(addOnAccessTokenDate);
                await _userManager.UpdateAsync(user);
            }
            else
                throw new NotFoundUserException();
        }

        public async Task UpdatePasswordAsync(string userId, string resetToken, string newPassword)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();
                IdentityResult result = await _userManager.ResetPasswordAsync(user, resetToken, newPassword);
                if (result.Succeeded)
                    await _userManager.UpdateSecurityStampAsync(user);
                else
                    throw new PasswordChangeFailedException();
            }
        }
        public async Task<List<ListUserDto>> GetAllUser()
        {
            var entities = await _userManager.Users.ToListAsync();
            return _mapper.Map<List<ListUserDto>>(entities);
        }
    }
}
