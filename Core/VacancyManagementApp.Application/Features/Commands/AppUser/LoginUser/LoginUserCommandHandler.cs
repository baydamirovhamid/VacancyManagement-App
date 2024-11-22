using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.Abstractions.Services.Authentications;

namespace VacancyManagementApp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommandRequest, LoginUserCommandResponse>
    {
        readonly IInternalAuthentication _internalAuthentication;

        public LoginUserCommandHandler(IInternalAuthentication internalAuthentication)
        {
            _internalAuthentication = internalAuthentication;
        }

        public async Task<LoginUserCommandResponse> Handle(LoginUserCommandRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var token = await _internalAuthentication.LoginAsync(request.UserNameOrEmail, request.Password, 900);

                return new LoginUserSuccessCommandResponse
                {
                    Token = token,
                    Message = "Login successful. Welcome!" 
                };
            }
            catch (Exception ex)
            {
                return new LoginUserErrorCommandResponse
                {
                    Message = "Login failed: " + ex.Message 
                };
            }
        }
    }
}
