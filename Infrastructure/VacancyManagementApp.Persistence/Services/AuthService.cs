using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VacancyManagementApp.Application.Abstractions.Services;
using VacancyManagementApp.Application.Abstractions.Token;
using VacancyManagementApp.Application.DTOs.Auth;
using VacancyManagementApp.Application.Exceptions;
using VacancyManagementApp.Domain.Entities.Identity;
using VacancyManagementApp.Application.Helpers;


namespace VacancyManagementApp.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly SignInManager<AppUser> _signInManager;
        readonly IUserService _userService;
        readonly IMailService _mailService;


        public AuthService(UserManager<AppUser> userManager, ITokenHandler tokenHandler, IConfiguration configuration, SignInManager<AppUser> signInManager, IUserService userService, IMailService mailService)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userService = userService;
            _mailService = mailService;
        }

        private async Task<Token> CreateUserExternalAsync(AppUser user, string email, string name, UserLoginInfo info, int accessTokenLifeTime)
        {
            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = email,
                        UserName = email,
                        NameSurname = name
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                await _userManager.AddLoginAsync(user, info); //AspNetUserLogins

                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                return token;
            }
            throw new Exception("Invalid external authentication.");
        }


        public async Task<Token> LoginAsync(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            try
            {
                AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
                if (user == null)
                    user = await _userManager.FindByEmailAsync(usernameOrEmail);

                if (user == null)
                    throw new NotFoundUserException();

                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
                if (result.Succeeded)
                {
                    Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime, user);
                    await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 15);
                    return token;
                }
                throw new AuthenticationErrorException();
            }
            catch (NotFoundUserException ex)
            {
                // Kullanıcı bulunamadığında yapılacak işlemler
                // Loglama yapabilir veya kullanıcıya uygun bir mesaj döndürebilirsiniz
                throw new Exception("Kullanıcı bulunamadı.", ex);
            }
            catch (AuthenticationErrorException ex)
            {
                // Kimlik doğrulama hatası durumunda yapılacak işlemler
                // Loglama yapabilir veya kullanıcıya uygun bir mesaj döndürebilirsiniz
                throw new Exception("Kimlik doğrulama hatası.", ex);
            }
            catch (Exception ex)
            {
                // Diğer hatalar için genel bir hata yönetimi
                throw new Exception("Bir hata oluştu.", ex);
            }
        }


        public async Task<Token> RefreshTokenLoginAsync(string refreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15, user);
                await _userService.UpdateRefreshTokenAsync(token.RefreshToken, user, token.Expiration, 300);
                return token;
            }
            else
                throw new NotFoundUserException();
        }

        public async Task ResetPasswordAsync(string email)
        {
            AppUser user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                resetToken = resetToken.UrlEncode();

                await _mailService.SendPasswordResetMailAsync(email, user.Id, resetToken);
            }
        }

        public async Task<bool> VerifyResetTokenAsync(string resetToken, string userId)
        {
            AppUser user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                resetToken = resetToken.UrlDecode();

                return await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", resetToken);
            }
            return false;
        }
    }
}
