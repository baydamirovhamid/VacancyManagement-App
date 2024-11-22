using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VacancyManagementApp.Application.DTOs.User;

namespace VacancyManagementApp.Application.Features.Queries.GetAllUser
{
    public class GetAllUserQueryResponse
    {
        public List<ListUserDto> GetAllUsers { get; set; }
    }
}
