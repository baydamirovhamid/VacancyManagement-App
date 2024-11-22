using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VacancyManagementApp.Application.Features.Commands.Vacancy.RemoveVacancy
{
    public class RemoveVacancyCommandResponse
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
    }
}
