using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.Result;

namespace VacancyManagementApp.Application.DTOs.User
{
    public class ListUserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public string UserName { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public List<GetAllResultDto> Results { get; set; }
    }
}
