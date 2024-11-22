using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Auth;

namespace VacancyManagementApp.Application.Features.Commands.AppUser.LoginUser
{
    public class LoginUserCommandResponse
    {
        public string Message { get; set; }
    }

    public class LoginUserSuccessCommandResponse : LoginUserCommandResponse
    {
        public Token Token { get; set; }
    }

    public class LoginUserErrorCommandResponse : LoginUserCommandResponse
    {
       
    }
}
